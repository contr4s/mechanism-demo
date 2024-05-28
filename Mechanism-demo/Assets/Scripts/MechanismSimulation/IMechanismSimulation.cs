using Camera;

namespace MechanismSimulation
{
    public interface IMechanismSimulation
    {
        IMechanism Mechanism { get; }

        void Init(IMechanism mechanism, ICameraController cameraController);
        void SwitchBlastState();
        void ShowMechanismPart(IMechanismPart mechanismPart);
        void ShowMechanism();
    }
}