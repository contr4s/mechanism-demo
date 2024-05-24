using UnityEngine;

namespace MechanismSimulation.PlanetarnyReductor
{
    public class ReductorPart : MonoBehaviour, IMechanismPart
    {
        [field: SerializeField] public Vector3 StartOffset { get; private set; }
        [field: SerializeField] public Vector3 BlastedOffset { get; private set; }
        
        public GameObject View => gameObject;
        public string Name => View.name;
    }
}