using System.Collections.Generic;

namespace MechanismSimulation
{
    public interface IMechanism
    {
        string Name { get; }
        IReadOnlyCollection<IMechanismPart> Parts { get; }

        void DoWork();
    }
}