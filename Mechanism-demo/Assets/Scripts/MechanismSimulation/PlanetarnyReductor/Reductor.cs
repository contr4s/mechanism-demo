using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace MechanismSimulation.PlanetarnyReductor
{
    public class Reductor : MonoBehaviour, IMechanism
    {
        [SerializeField] private ReductorPart[] parts;
        [SerializeField] private float rotationSpeed;
        [field: SerializeField] public string Name { get; private set; }

        public IReadOnlyCollection<IMechanismPart> Parts => parts;
        
        public void DoWork()
        {
            StartCoroutine(Rotate(CancellationToken.None));
        }

        private IEnumerator Rotate(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested) {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}