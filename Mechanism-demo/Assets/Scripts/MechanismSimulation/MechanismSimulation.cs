using System;
using System.Threading;
using Camera;
using Camera.Settings;
using Cysharp.Threading.Tasks;
using Extensions;
using MechanismSimulation.Extensions;
using Zenject;

namespace MechanismSimulation
{
    public class MechanismSimulation : IInitializable, IDisposable, IMechanismSimulation
    {
        private readonly MechanismSimulationConfig _config;
        private readonly FreeLookCamSettings _cameraSettings;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private ICameraController _cameraController;

        public IMechanism Mechanism { get; private set; }

        public MechanismSimulation(MechanismSimulationConfig config)
        {
            _config = config;
            _cameraSettings = new FreeLookCamSettings(config.CameraSmoothSpeed);
        }

        public void Init(IMechanism mechanism, ICameraController cameraController)
        {
            Mechanism = mechanism;
            _cameraController = cameraController;
        }

        public void SwitchBlastState()
        {
            Mechanism.ShowAllParts();
            _cancellationTokenSource = _cancellationTokenSource.Refresh();
            Mechanism.SwitchBlastState(_config.BlastSpeed, _cancellationTokenSource.Token).Forget();
            _cameraController.ApplyOnCurrentCamera(_cameraSettings.SetOffsets(Offsets.Zero)
                                                                  .SetFov(Mechanism.CameraFov));
        }

        public void ShowMechanism()
        {
            Mechanism.ShowAllParts();
            _cameraController.ApplyOnCurrentCamera(_cameraSettings.SetOffsets(Offsets.Zero)
                                                                  .SetFov(Mechanism.CameraFov));
        }

        public void ShowMechanismPart(IMechanismPart mechanismPart)
        {
            Mechanism.HideAllParts();
            mechanismPart.View.SetActive(true);
            var offsets = Mechanism.BlastState
                                  ? mechanismPart.CameraParameters.Offsets.Move(mechanismPart.BlastedOffset)
                                  : mechanismPart.CameraParameters.Offsets;

            _cameraController.ApplyOnCurrentCamera(_cameraSettings.SetOffsets(offsets)
                                                                  .SetFov(mechanismPart.CameraParameters.Fov));
        }

        void IInitializable.Initialize()
        {
            Mechanism?.DoWork();
        }

        void IDisposable.Dispose()
        {
            _cancellationTokenSource.Dispose();
            _cameraSettings.Dispose();
        }
    }
}