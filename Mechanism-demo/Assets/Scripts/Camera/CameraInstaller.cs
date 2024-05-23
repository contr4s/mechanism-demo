using Camera.Settings;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Camera
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineBrain _cinemachineBrain;
        [SerializeField] private CameraSettingsConfig _cameraSettingsConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<CinemachineBrain>().FromInstance(_cinemachineBrain).AsSingle();
            Container.Bind<CameraSettingsConfig>().FromInstance(_cameraSettingsConfig).AsSingle();
            Container.BindInterfacesTo<CameraController>().AsSingle();
        }
    }
}