using UnityEngine;

namespace MechanismSimulation
{
    public interface IMechanismPart
    {
        GameObject View { get; }
        Vector3 StartOffset { get; }
        Vector3 BlastedOffset { get; }
    }
}