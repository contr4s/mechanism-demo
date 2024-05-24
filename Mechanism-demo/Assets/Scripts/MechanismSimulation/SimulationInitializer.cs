using UI.Window;
using UI.Window.MechanismSimulation;
using UI.Window.ShowProcessors;
using Zenject;

namespace MechanismSimulation
{
    public class SimulationInitializer : IInitializable
    {
        private readonly IWindowShowController _windowShowController;
        private readonly IMechanismSimulation _mechanismSimulation;

        public SimulationInitializer(IWindowShowController windowShowController, IMechanismSimulation mechanismSimulation)
        {
            _windowShowController = windowShowController;
            _mechanismSimulation = mechanismSimulation;
        }

        public void Initialize()
        {
            _windowShowController.Show<MechanismSimulationWindow, ConsistentShowProcessor, IMechanismSimulation>(_mechanismSimulation);
        }
    }
}