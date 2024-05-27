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
        
        private bool _isBlast;
        
        [field: SerializeField] public string Name { get; private set; }

        public IReadOnlyCollection<IMechanismPart> Parts => parts;
        public float CameraFov { get; private set; }
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
            _isBlast = !_isBlast;
            CameraFov = _isBlast ? blastCameraFov : defaultCameraFov;
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