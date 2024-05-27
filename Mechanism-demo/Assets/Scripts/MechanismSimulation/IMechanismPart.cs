using Camera.Settings;
using UnityEngine;

namespace MechanismSimulation
{
    public interface IMechanismPart
    {
        string Name { get; }
        GameObject View { get; }
        Vector3 StartOffset { get; }
        Vector3 BlastedOffset { get; }
        CameraParameters CameraParameters { get; }
    }
}