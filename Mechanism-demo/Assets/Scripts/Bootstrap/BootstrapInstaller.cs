using Zenject;

namespace Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Bootstrap>().AsSingle();
        }
    }
}