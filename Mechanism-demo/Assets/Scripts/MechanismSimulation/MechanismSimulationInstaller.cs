using MechanismSimulation.PlanetarnyReductor;
using UnityEngine;
using Zenject;

namespace MechanismSimulation
{
    public class MechanismSimulationInstaller : MonoInstaller
    {
        [SerializeField] private Reductor reductor;
        [SerializeField] private MechanismSimulationConfig config;
        
        public override void InstallBindings()
        {
            Container.BindInstance(config).AsSingle();
            Container.Bind<IMechanism>().FromInstance(reductor).AsSingle();
            Container.BindInterfacesAndSelfTo<MechanismSimulation>().AsSingle();
        }
    }
}