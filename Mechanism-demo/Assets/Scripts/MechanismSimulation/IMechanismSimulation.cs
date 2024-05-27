namespace MechanismSimulation
{
    public interface IMechanismSimulation
    {
        IMechanism Mechanism { get; }
        
        void SwitchBlastState();
        void ShowMechanismPart(IMechanismPart mechanismPart);
        void ShowMechanism();
    }
}