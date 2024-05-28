using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Extensions;
using MechanismSimulation;
using ObjectPool;
using Scene;
using UI.Elements;
using UI.Window.Common;
using UI.Window.ShowProcessors;
using UniRx;

namespace UI.Window.MechanismSimulation
{
    public class MechanismSimulationBinder : WindowBinder<MechanismSimulationWindow, IMechanismSimulation>, IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        private readonly SceneConfig _sceneConfig;
        private readonly IPoolingObjectsProvider _poolingObjectsProvider;

        protected override bool RebindEqual => true;

        public MechanismSimulationBinder(IPoolingObjectsProvider poolingObjectsProvider, SceneConfig sceneConfig)
        {
            _poolingObjectsProvider = poolingObjectsProvider;
            _sceneConfig = sceneConfig;
        }

        protected override void BindInternal(MechanismSimulationWindow view, IMechanismSimulation model)
        {
            view.ReturnButton.OnClickAsObservable()
                .Subscribe(ReturnBack)
                .AddTo(view.BindingContainer);
            
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
        
        private void ReturnBack(Unit _)
        {
            ReturnBack().Forget();
        }
        
        private async UniTaskVoid ReturnBack()
        {
            _cancellationTokenSource = _cancellationTokenSource.Refresh();
            ShowController.Show<LoadingWindow, ParallelShowProcessor>();
            await SceneUtil.LoadScene(_sceneConfig.StartSceneIndex, _cancellationTokenSource.Token,
                                      _sceneConfig.SimulationSceneIndex);
            ShowController.Show<StartWindow.StartWindow, ParallelShowProcessor, EmptyWindowModel>(new EmptyWindowModel());
        }

        void IDisposable.Dispose()
        {
            _cancellationTokenSource?.Dispose();
        }
    }
}