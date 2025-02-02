﻿using System.Collections.Generic;
using UI.Common;

namespace UI.Window.Common
{
    public abstract class WindowBinder<TWindow, TModel> : IWindowBinder, IBinder<TWindow, TModel>
            where TWindow : WindowView where TModel : class
    {
        private readonly Dictionary<TWindow, TModel> _bindings = new Dictionary<TWindow, TModel>();

        public IWindowShowController ShowController { get; set; }
        
        protected virtual bool RebindEqual => false;

        public void Bind(TWindow view, TModel model)
        {
            if (_bindings.TryGetValue(view, out TModel boundModel))
            {
                if (!RebindEqual && ReferenceEquals(boundModel, model))
                {
                    return;
                }

                Unbind(view);
            }

            BindInternal(view, model);
            _bindings.Add(view, model);
        }

        public void Unbind(TWindow view)
        {
            view.ResetBindings();
            _bindings.Remove(view);
        }

        protected abstract void BindInternal(TWindow view, TModel model);
    }
}