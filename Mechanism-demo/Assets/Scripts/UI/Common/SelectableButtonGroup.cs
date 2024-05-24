using System;
using System.Collections.Generic;
using UniRx;

namespace UI.Common
{
    public class SelectableButtonGroup<T> where T : class, ISelectableButton
    {
        private readonly List<T> _buttons = new List<T>();
        
        public IReadOnlyCollection<T> Buttons => _buttons;
        public T SelectedButton { get; private set; }

        public void AddButton(T button, ICollection<IDisposable> bindingsContainer, Action<T> afterSelect = null, Action afterAllDeselect = null)
        {
            _buttons.Add(button);
            button.Button.OnClickAsObservable().Subscribe(Select).AddTo(bindingsContainer);

            return;

            void Select(Unit _)
            {
                SelectedButton?.SwitchSelection();
                if (ReferenceEquals(SelectedButton, button))
                {
                    SelectedButton = null;
                    afterAllDeselect?.Invoke();
                    return;
                }

                button.SwitchSelection();
                SelectedButton = button;
                afterSelect?.Invoke(button);
            }
        }

        public void Deselect()
        {
            SelectedButton?.SwitchSelection();
            SelectedButton = null;
        }
        
        public void Clear() => _buttons.Clear();
    }
}