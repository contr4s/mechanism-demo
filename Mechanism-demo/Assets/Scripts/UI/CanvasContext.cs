using UI.Window;
using UI.Window.Common;
using UI.Window.ShowProcessors;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UI
{
    public class CanvasContext : UIBehaviour
    {
        [SerializeField] private WindowView[] windowViews;
        
        [Inject]
        public void Construct(IWindowShowController windowShowController)
        {
            windowShowController.Setup(windowViews);
            windowShowController.Show<LoadingWindow, InstantlyShowProcessor>();
        }
    }
}