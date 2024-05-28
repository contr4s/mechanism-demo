using Camera;
using MechanismSimulation;
using UnityEngine;
using Zenject;

namespace Resolvers
{
    public class SimulationResolver : IInitializable
    {
        private readonly IMechanismSimulation _mechanismSimulation;
        private readonly ICameraController _cameraController;
        private readonly IMechanism _mechanism;
        
        public SimulationResolver(IMechanismSimulation mechanismSimulation,
                                  [Inject(Source = InjectSources.Local, Optional = true)] IMechanism mechanism,
                                  [Inject(Source = InjectSources.Local, Optional = true)] ICameraController cameraController)
        {
            _mechanismSimulation = mechanismSimulation;
            _mechanism = mechanism;
            _cameraController = cameraController;
        }

        public void Initialize()
        {
            _mechanismSimulation.Init(_mechanism, _cameraController);
        }
    }
}