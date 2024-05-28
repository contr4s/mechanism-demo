using UnityEngine;
using Zenject;

namespace MechanismSimulation
{
    public class MechanismSimulationInstaller : MonoInstaller
    {
        [SerializeField] private MechanismSimulationConfig config;
        
        public override void InstallBindings()
        {
            Container.BindInstance(config).AsSingle();
            Container.BindInterfacesTo<MechanismSimulation>().AsSingle();
        }
    }
}