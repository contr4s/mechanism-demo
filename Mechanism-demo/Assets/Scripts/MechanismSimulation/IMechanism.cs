using System.Collections.Generic;

namespace MechanismSimulation
{
    public interface IMechanism
    {
        IReadOnlyCollection<IMechanismPart> Parts { get; }

        void DoWork();
    }
}