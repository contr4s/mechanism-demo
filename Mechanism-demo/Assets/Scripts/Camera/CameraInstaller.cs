using Camera.Settings;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Camera
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineBrain _cinemachineBrain;
        
        public override void InstallBindings()
        {
            Container.Bind<CinemachineBrain>().FromInstance(_cinemachineBrain).AsSingle();
            Container.BindInterfacesTo<CameraController>().AsSingle();
        }
    }
}