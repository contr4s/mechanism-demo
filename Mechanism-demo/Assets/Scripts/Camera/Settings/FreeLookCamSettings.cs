using System;
using System.Threading;
using Cinemachine;
using Cysharp.Threading.Tasks;
using Extensions;

namespace Camera.Settings
{
    public class FreeLookCamSettings : ICameraSettings<CinemachineFreeLook>, IDisposable
    {
        private readonly float _smoothSpeed;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        private float _fov;
        private Offsets _offsets;
        
        public FreeLookCamSettings(float smoothSpeed, float fov = 40)
        {
            _smoothSpeed = smoothSpeed;
            _fov = fov;
            _offsets = Offsets.Zero;
        }
        
        public FreeLookCamSettings SetFov(float fov)
        {
            _fov = fov;
            return this;
        }
        
        public FreeLookCamSettings SetDefaultOffsets()
        {
            _offsets = Offsets.Zero;
            return this;
        }
        
        public FreeLookCamSettings SetParameters(CameraParameters parameters)
        {
            _offsets = parameters.Offsets;
            return SetFov(parameters.Fov);
        }

        public void Apply(CinemachineFreeLook camera)
        {
            _cancellationTokenSource = _cancellationTokenSource.Refresh();

            camera.ChangeParameterSmooth(x => x.m_Lens.FieldOfView, 
                                                (lens, val) => lens.m_Lens.FieldOfView = val, 
                                                _fov, _smoothSpeed, _cancellationTokenSource.Token).Forget();
            for (int i = 0; i < Offsets.Count; i++)
            {
                CinemachineVirtualCamera rig = camera.GetRig(i);
                var composer = rig.GetCinemachineComponent<CinemachineComposer>();
                composer.ChangeParameterSmooth(x => x.m_TrackedObjectOffset,
                                                (comp, val) => comp.m_TrackedObjectOffset = val,
                                                _offsets[i], _smoothSpeed, _cancellationTokenSource.Token).Forget();
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource.Dispose();
        }
    }
}