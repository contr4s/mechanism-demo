using Camera.Settings;
using Cinemachine;
using Extensions;
using UnityEngine;
using Zenject;

namespace Camera
{
    public class CameraController : ICameraController
    {
        private readonly CinemachineBrain _cinemachineBrain;
        
        public CameraController(CinemachineBrain cinemachineBrain)
        {
            _cinemachineBrain = cinemachineBrain;
        }

        public void ApplyOnCurrentCamera<T>(ICameraSettings<T> settings) where T : ICinemachineCamera
        {
            if (!_cinemachineBrain.TryGetCurrentCamera(out T camera))
            {
                Debug.LogError($"Current camera is not of type {typeof(T)}");
                return;
            }
            
            settings.Apply(camera);
        }
    }
}