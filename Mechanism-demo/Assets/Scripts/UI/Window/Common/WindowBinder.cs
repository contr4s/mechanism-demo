using System.Collections.Generic;
using UI.Common;

namespace UI.Window.Common
{
    public abstract class WindowBinder<TWindow, TModel> : IWindowBinder, IBinder<TWindow, TModel>
            where TWindow : WindowView where TModel : class
    {
        private readonly Dictionary<TWindow, TModel> _bindings = new Dictionary<TWindow, TModel>();

        public IWindowShowController ShowController { get; set; }

        public void Bind(TWindow view, TModel model)
        {
            if (_bindings.TryGetValue(view, out TModel boundModel))
            {
                if (ReferenceEquals(boundModel, model))
                {
                    return;
                }

                Unbind(view);
            }

            BindInternal(view, model);
        }

        public void Unbind(TWindow view)
        {
            view.ResetBindings();
        }

        protected abstract void BindInternal(TWindow view, TModel model);
    }
}