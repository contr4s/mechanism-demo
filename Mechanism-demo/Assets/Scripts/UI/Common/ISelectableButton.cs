using ObjectPool;
using UnityEngine.UI;

namespace UI.Common
{
    public interface ISelectableButton : IResettable
    {
        Button Button { get; }
        bool IsSelected { get; }
        
        void SwitchSelection();
    }
}