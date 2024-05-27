using UnityEngine;

namespace MechanismSimulation
{
    [CreateAssetMenu(fileName = "MechanismSimulationCfg", menuName = "Configs/MechanismSimulation", order = 0)]
    public class MechanismSimulationConfig : ScriptableObject
    {
        [field: SerializeField] public float BlastSpeed { get; private set; }
        [field: SerializeField] public float CameraSmoothSpeed { get; private set; }
    }
}