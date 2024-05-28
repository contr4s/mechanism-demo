using Extensions;
using UI.Common;
using UI.Window;
using UI.Window.Common;
using Zenject;

namespace UI
{
    public class UiSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindAllImplementationsOfType<IBinder>();
            Container.BindAllImplementationsOfType<IWindowShowProcessor>();
            
            Container.BindInterfacesAndSelfTo<BinderAggregator>().AsSingle();
            Container.BindInterfacesTo<WindowShowController>().AsSingle();
            Container.BindInterfacesAndSelfTo<EmptyWindowModel>().AsSingle();
        }
    }
}