using Extensions;
using UI.Common;
using UI.Window;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UiSystemInstaller : MonoInstaller
    {
        [SerializeField] private WindowViewsData _windowsViews;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_windowsViews);
            
            Container.BindAllImplementationsOfType<IBinder>();
            Container.BindAllImplementationsOfType<IWindowShowProcessor>();
            
            Container.BindInterfacesAndSelfTo<BinderAggregator>().AsSingle();
            Container.BindInterfacesTo<WindowShowController>().AsSingle();

            Container.BindInterfacesTo<UiInitializer>().AsSingle();
        }
    }
}