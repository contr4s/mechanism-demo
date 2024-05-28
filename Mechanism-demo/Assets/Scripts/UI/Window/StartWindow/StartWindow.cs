using UI.Window.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window.StartWindow
{
    public class StartWindow : CanvasWindowView
    {
        [field: SerializeField] public Button StartButton { get; private set; }
        [field: SerializeField] public Button QuitButton { get; private set; }
    }
}