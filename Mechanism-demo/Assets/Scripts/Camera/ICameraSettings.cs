using Cinemachine;

namespace Camera
{
    public interface ICameraSettings<in T> where T : ICinemachineCamera
    {
        void Apply(T camera);
    }
}