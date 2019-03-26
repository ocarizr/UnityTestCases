using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiTest
{
    public class ManageToggleText : MonoBehaviour
    {
        public Text ToggleLabel;

        private Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(UpdateText);
        }

        private void UpdateText(bool isOn)
        {
            ToggleLabel.text = isOn ? "Accepted subscription terms." : "Accept subscription terms.";
        }
    }
}

