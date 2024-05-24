using System.Collections.Generic;

namespace UI.Window
{
    public interface IWindowShowController
    {
        void Setup(ICollection<WindowView> windows);
        
        void Show<TWindow, TProcessor>() where TWindow : WindowView
                                         where TProcessor : IWindowShowProcessor;

        void Show<TWindow, TProcessor, TModel>(TModel model) where TWindow : WindowView
                                                             where TProcessor : IWindowShowProcessor;

    }
}