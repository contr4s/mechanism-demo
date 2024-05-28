using Zenject;

namespace Resolvers
{
    public class ResolversInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SimulationResolver>().AsSingle().CopyIntoDirectSubContainers();
        }
    }
}