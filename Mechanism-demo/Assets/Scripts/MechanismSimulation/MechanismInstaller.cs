using MechanismSimulation.PlanetarnyReductor;
using UnityEngine;
using Zenject;

namespace MechanismSimulation
{
    public class MechanismInstaller : MonoInstaller
    {
        [SerializeField] private Reductor reductor;
        
        public override void InstallBindings()
        {
            Container.Bind<IMechanism>().FromInstance(reductor).AsSingle();
            Container.BindInterfacesAndSelfTo<MechanismInitializer>().AsSingle();
        }
    }
}