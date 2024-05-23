using Camera.Settings;
using Cinemachine;
using Extensions;
using UnityEngine;
using Zenject;

namespace Camera
{
    public class CameraController : ICameraController, IInitializable
    {
        private readonly CinemachineBrain _cinemachineBrain;
        private readonly CameraSettingsConfig _cameraSettingsConfig;
        
        public CameraController(CinemachineBrain cinemachineBrain, CameraSettingsConfig cameraSettingsConfig)
        {
            _cinemachineBrain = cinemachineBrain;
            _cameraSettingsConfig = cameraSettingsConfig;
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

        void IInitializable.Initialize()
        {
            ApplyOnCurrentCamera(new FreeLookCamSettings(_cameraSettingsConfig.DefaultParameters));
        }
    }
}