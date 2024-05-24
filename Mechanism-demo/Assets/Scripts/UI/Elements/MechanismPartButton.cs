using MechanismSimulation;
using TMPro;
using UI.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Elements
{
    public class MechanismPartButton : UIBehaviour, ISelectableButton
    {
        [SerializeField] private Image image;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color selectedColor;
        [SerializeField] private TMP_Text nameText;
        
        [field: SerializeField] public Button Button { get; private set; }
        
        public bool IsSelected { get; private set; }
        public IMechanismPart MechanismPart { get; private set; }
        
        public void SwitchSelection()
        {
            IsSelected = !IsSelected;
            image.color = IsSelected ? selectedColor : defaultColor;
        }
        
        public void SetMechanismPart(IMechanismPart mechanismPart)
        {
            MechanismPart = mechanismPart;
            nameText.text = mechanismPart.Name;
        }

        public void ResetDefaults()
        {
            Button.onClick.RemoveAllListeners();
            IsSelected = false;
            image.color = defaultColor;
        }
    }
}