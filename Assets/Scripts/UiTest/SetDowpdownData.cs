using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UiTest
{
    public class SetDowpdownData : MonoBehaviour
    {
        private TMP_Dropdown _stateDropdown;

        private void Awake()
        {
            _stateDropdown = GetComponent<TMP_Dropdown>();
            _stateDropdown.ClearOptions();

            var options = new List<TMP_Dropdown.OptionData>();
            foreach (object value in Enum.GetValues(typeof(BrazilStates)))
            {
                options.Add(new TMP_Dropdown.OptionData(value.ToString()));
            }

            _stateDropdown.options = options;
        }
    }

    public enum BrazilStates
    {
        AC, AL, AP, AM, BA, CE, DF, ES, GO,
        MA, MT, MS, MG, PA, PB, PR, PE, PI,
        RJ, RN, RS, RO, RR, SC, SP, SE, TO
    }
}
