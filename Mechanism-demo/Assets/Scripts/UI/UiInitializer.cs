using UI.Window;
using UI.Window.ShowProcessors;
using Zenject;

namespace UI
{
    public class UiInitializer : IInitializable
    {
        private readonly IWindowShowController _windowShowController;

        public UiInitializer(IWindowShowController windowShowController)
        {
            _windowShowController = windowShowController;
        }

        public void Initialize() { }
    }
}