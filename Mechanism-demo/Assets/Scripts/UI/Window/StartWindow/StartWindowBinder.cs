using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Extensions;
using MechanismSimulation;
using Scene;
using UI.Window.Common;
using UI.Window.MechanismSimulation;
using UI.Window.ShowProcessors;
using UniRx;
using UnityEngine;

namespace UI.Window.StartWindow
{
    public class StartWindowBinder : WindowBinder<StartWindow, EmptyWindowModel>, IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        private readonly SceneConfig _sceneConfig;
        private readonly IMechanismSimulation _mechanismSimulation;
        
        public StartWindowBinder(SceneConfig sceneConfig, IMechanismSimulation mechanismSimulation)
        {
            _sceneConfig = sceneConfig;
            _mechanismSimulation = mechanismSimulation;
        }

        protected override void BindInternal(StartWindow view, EmptyWindowModel model)
        {
            view.StartButton.OnClickAsObservable().Subscribe(StartSimulation).AddTo(view.BindingContainer);
            view.QuitButton.OnClickAsObservable().Subscribe(_ => Application.Quit()).AddTo(view.BindingContainer);
        }

        private void StartSimulation(Unit _)
        {
            StartSimulation().Forget();
        }

        private async UniTaskVoid StartSimulation()
        {
            _cancellationTokenSource = _cancellationTokenSource.Refresh();
            ShowController.Show<LoadingWindow, ParallelShowProcessor>();
            await SceneUtil.LoadScene(_sceneConfig.SimulationSceneIndex, _cancellationTokenSource.Token,
                                      _sceneConfig.StartSceneIndex);
            ShowController.Show<MechanismSimulationWindow, ParallelShowProcessor, IMechanismSimulation>(_mechanismSimulation);
        }

        public void Dispose()
        {
            _cancellationTokenSource.Dispose();
        }
    }
}