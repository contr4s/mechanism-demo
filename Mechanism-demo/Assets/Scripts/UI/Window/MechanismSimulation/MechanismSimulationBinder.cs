using Camera;
using Camera.Settings;
using MechanismSimulation;
using MechanismSimulation.Extensions;
using ObjectPool;
using UI.Elements;
using UI.Window.Common;
using UniRx;

namespace UI.Window.MechanismSimulation
{
    public class MechanismSimulationBinder : WindowBinder<MechanismSimulationWindow, IMechanismSimulation>
    {
        private readonly IPoolingObjectsProvider _poolingObjectsProvider;

        public MechanismSimulationBinder(IPoolingObjectsProvider poolingObjectsProvider)
        {
            _poolingObjectsProvider = poolingObjectsProvider;
        }

        protected override void BindInternal(MechanismSimulationWindow view, IMechanismSimulation model)
        {
            view.MechanismButton.SetName(model.Mechanism.Name);
            view.MechanismButton.Button.OnClickAsObservable()
                .Subscribe(SwitchBlastState)
                .AddTo(view.BindingContainer);

            foreach (MechanismPartButton partButton in view.MechanismPartButtonGroup.Buttons)
            {
                _poolingObjectsProvider.ReturnToPool(partButton);
            }
            view.MechanismPartButtonGroup.Clear();
            
            foreach (IMechanismPart part in model.Mechanism.Parts)
            {
                MechanismPartButton partButton = _poolingObjectsProvider.GetFromPool(view.MechanismPartButtonPrefab);
                partButton.transform.SetParent(view.MechanismPartButtonParent, false);
                partButton.SetMechanismPart(part);
                view.MechanismPartButtonGroup.AddButton(partButton, 
                                                        view.BindingContainer,
                                                        AfterSelect,
                                                        model.ShowMechanism);
            }
            
            return;
            
            void SwitchBlastState(Unit _)
            {
                view.MechanismPartButtonGroup.Deselect();
                model.SwitchBlastState();
            }

            void AfterSelect(MechanismPartButton x)
            {
                model.ShowMechanismPart(x.MechanismPart);
            }
        }
    }
}