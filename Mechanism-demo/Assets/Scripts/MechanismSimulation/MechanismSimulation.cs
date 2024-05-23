using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Extensions;
using MechanismSimulation.Extensions;
using Zenject;

namespace MechanismSimulation
{
    public class MechanismSimulation : IInitializable, IDisposable
    {
        private readonly IMechanism _mechanism;
        private readonly MechanismSimulationConfig _config;
        
        private CancellationTokenSource _cancellationTokenSource;
        
        public MechanismSimulation(IMechanism mechanism, MechanismSimulationConfig config)
        {
            _mechanism = mechanism;
            _config = config;
        }

        public void ShowMechanism()
        {
            _mechanism.ShowAllParts();
        }
        
        public void SwitchBlastState(bool isBlast)
        {
            _cancellationTokenSource = _cancellationTokenSource?.Refresh();
            _mechanism.SwitchBlastState(isBlast, _config.BlastSpeed, _cancellationTokenSource.Token).Forget();
        }
        
        public void ShowMechanismPart(IMechanismPart mechanismPart)
        {
            _mechanism.HideAllParts();
            mechanismPart.View.SetActive(true);
        }

        public void Initialize()
        {
            _mechanism.DoWork();
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
        }
    }
}