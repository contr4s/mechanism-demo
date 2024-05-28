using UI.Common;
using UI.Elements;
using UI.Window.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window.MechanismSimulation
{
    public class MechanismSimulationWindow : CanvasWindowView
    {
        [field: SerializeField] public MechanismButton MechanismButton { get; private set; }
        [field: SerializeField] public MechanismPartButton MechanismPartButtonPrefab { get; private set; }
        [field: SerializeField] public Transform MechanismPartButtonParent { get; private set; }
        [field: SerializeField] public Button ReturnButton { get; private set; }

        public SelectableButtonGroup<MechanismPartButton> MechanismPartButtonGroup { get; private set; }
            = new SelectableButtonGroup<MechanismPartButton>();
    }
}