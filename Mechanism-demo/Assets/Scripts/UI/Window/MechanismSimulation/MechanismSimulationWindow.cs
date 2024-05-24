using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UnityEngine;

namespace UI.Window.MechanismSimulation
{
    public class MechanismSimulationWindow : WindowView
    {
        [field: SerializeField] public MechanismButton MechanismButton { get; private set; }
        [field: SerializeField] public MechanismPartButton MechanismPartButtonPrefab { get; private set; }
        [field: SerializeField] public Transform MechanismPartButtonParent { get; private set; }

        public SelectableButtonGroup<MechanismPartButton> MechanismPartButtonGroup { get; private set; }
            = new SelectableButtonGroup<MechanismPartButton>();
    }
}