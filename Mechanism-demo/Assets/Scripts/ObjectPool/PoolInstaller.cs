using Zenject;

namespace ObjectPool
{
    public class PoolInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PoolingObjectsProvider>().AsSingle();
        }
    }
}