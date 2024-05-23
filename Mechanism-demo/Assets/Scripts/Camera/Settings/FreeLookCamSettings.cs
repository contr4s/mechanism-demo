using Cinemachine;

namespace Camera.Settings
{
    public class FreeLookCamSettings : ICameraSettings<CinemachineFreeLook>
    {
        private readonly CameraParameters _config;
        
        public FreeLookCamSettings(CameraParameters config)
        {
            _config = config;
        }

        public void Apply(CinemachineFreeLook camera)
        {
            camera.m_Lens.FieldOfView = _config.Fov;
        }
    }
}