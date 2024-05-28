using System.Threading;
using Cysharp.Threading.Tasks;
using Scene;
using UI.Window;
using UI.Window.Common;
using UI.Window.ShowProcessors;
using UI.Window.StartWindow;
using Zenject;

namespace Bootstrap
{
    public class Bootstrap : IInitializable
    {
        private readonly IWindowShowController _windowShowController;
        
        public Bootstrap(IWindowShowController windowShowController)
        {
            _windowShowController = windowShowController;
        }

        public void Initialize()
        {
            SceneUtil.LoadScene(1, CancellationToken.None).Forget();
            _windowShowController.Show<StartWindow, ConsistentShowProcessor, EmptyWindowModel>(new EmptyWindowModel());
        }
    }
}
