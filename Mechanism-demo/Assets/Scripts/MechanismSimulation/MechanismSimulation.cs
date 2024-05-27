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
        private readonly ICameraController _cameraController;
        private readonly FreeLookCamSettings _cameraSettings;
        
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private bool _isBlast;
        
        public IMechanism Mechanism { get; }

        public MechanismSimulation(IMechanism mechanism, MechanismSimulationConfig config, ICameraController cameraController)
        {
            Mechanism = mechanism;
            _config = config;
            _cameraController = cameraController;
            _cameraSettings = new FreeLookCamSettings(config.CameraSmoothSpeed);
        }
        
        public void SwitchBlastState()
        {
            Mechanism.ShowAllParts();
            _cancellationTokenSource = _cancellationTokenSource.Refresh();
            _isBlast = !_isBlast;
            Mechanism.SwitchBlastState(_isBlast, _config.BlastSpeed, _cancellationTokenSource.Token).Forget();
            _cameraController.ApplyOnCurrentCamera(_cameraSettings.SetDefaultOffsets().SetFov(Mechanism.CameraFov));
        }

        public void ShowMechanism()
        {
            Mechanism.ShowAllParts();
            _cameraController.ApplyOnCurrentCamera(_cameraSettings.SetDefaultOffsets().SetFov(Mechanism.CameraFov));
        }
        
        public void ShowMechanismPart(IMechanismPart mechanismPart)
        {
            Mechanism.HideAllParts();
            mechanismPart.View.SetActive(true);
            _cameraController.ApplyOnCurrentCamera(_cameraSettings.SetParameters(mechanismPart.CameraParameters));
        }

        void IInitializable.Initialize()
        {
            Mechanism.DoWork();
        }

        void IDisposable.Dispose()
        {
            _cancellationTokenSource.Dispose();
            _cameraSettings.Dispose();
        }
    }
}