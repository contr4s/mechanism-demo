using UI.Window;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UI
{
    public class CanvasContext : UIBehaviour
    {
        [SerializeField] private WindowView[] windowViews;

        private IWindowShowController _windowShowController;
        
        [Inject]
        public void Construct(IWindowShowController windowShowController)
        {
            windowShowController.Setup(windowViews);
        }
    }
}