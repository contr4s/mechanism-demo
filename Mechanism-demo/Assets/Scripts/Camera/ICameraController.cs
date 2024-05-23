using Cinemachine;

namespace Camera
{
    public interface ICameraController
    {
        void ApplyOnCurrentCamera<T>(ICameraSettings<T> settings) where T : ICinemachineCamera;
    }
}