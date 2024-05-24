using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Elements
{
    public class MechanismButton : UIBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        
        [field: SerializeField] public Button Button { get; private set; }
        
        public void SetName(string name) => nameText.text = name;
    }
}