using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Extensions;
using MechanismSimulation.Extensions;
using Zenject;

namespace MechanismSimulation
{
    public class MechanismSimulation : IInitializable, IDisposable, IMechanismSimulation
    {
        private readonly MechanismSimulationConfig _config;
        
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private bool _isBlast;
        
        public IMechanism Mechanism { get; }

        public MechanismSimulation(IMechanism mechanism, MechanismSimulationConfig config)
        {
            Mechanism = mechanism;
            _config = config;
        }
        
        public void SwitchBlastState()
        {
            Mechanism.ShowAllParts();
            _cancellationTokenSource = _cancellationTokenSource.Refresh();
            _isBlast = !_isBlast;
            Mechanism.SwitchBlastState(_isBlast, _config.BlastSpeed, _cancellationTokenSource.Token).Forget();
        }
        
        public void ShowMechanismPart(IMechanismPart mechanismPart)
        {
            Mechanism.HideAllParts();
            mechanismPart.View.SetActive(true);
        }

        void IInitializable.Initialize()
        {
            Mechanism.DoWork();
        }

        void IDisposable.Dispose()
        {
            _cancellationTokenSource.Dispose();
        }
    }
}