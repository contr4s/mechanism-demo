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
        [SerializeField] private float defaultCameraFov;
        [SerializeField] private float blastCameraFov;

        [field: SerializeField] public string Name { get; private set; }

        public IReadOnlyCollection<IMechanismPart> Parts => parts;
        public float CameraFov { get; private set; }
        public bool BlastState { get; private set; }

        public Transform Transform => transform;

        private void Awake()
        {
            CameraFov = defaultCameraFov;
        }

        public void DoWork()
        {
            StartCoroutine(Rotate(CancellationToken.None));
        }

        public void SwitchBlastState()
        {
            BlastState = !BlastState;
            CameraFov = BlastState ? blastCameraFov : defaultCameraFov;
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