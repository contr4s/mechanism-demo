using Camera;
using MechanismSimulation.Extensions;
using Zenject;

namespace MechanismSimulation
{
    public class MechanismInitializer : IInitializable
    {
        private readonly IMechanism _mechanism;
        
        public MechanismInitializer(IMechanism mechanism)
        {
            _mechanism = mechanism;
        }

        public void Initialize()
        {
            _mechanism.ShowAllParts();
            if (_mechanism.BlastState)
            {
                _mechanism.SwitchBlastState();
            }

            foreach (IMechanismPart part in _mechanism.Parts)
            {
                part.View.transform.localPosition = part.StartOffset;
            }
        }
    }
}