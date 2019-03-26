using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.UiTest
{
    public class FormManager : SaveSystem<Data>
    {
        public TMP_InputField NameInput;
        public TMP_InputField AddressInput;
        public TMP_InputField NumberInput;
        public TMP_InputField CityInput;
        public TMP_Dropdown StateDropdown;
        public TMP_InputField EmailInput;
        public Toggle AgreedToggle;
        public Button SaveButton;

        public void Awake()
        {
            SaveButton.onClick.AddListener(SaveData);
        }

        public override void SaveData()
        {
            string name = NameInput.text;
            string address = AddressInput.text;
            int.TryParse(NumberInput.text, out int number);
            string city = CityInput.text;
            string state = StateDropdown.options[StateDropdown.value].text;
            string email = EmailInput.text;
            bool agreed = AgreedToggle.isOn;

            var data = new Data(name, address, number, city, state, email, agreed);

            BinarySaveFile(data);
        }
    }

    public class Data
    {
        public string Name { get; }
        public string Address { get; }
        public int Number { get; }
        public string City { get; }
        public string State { get; }
        public string Email { get; }
        public bool Agreed { get; }

        public Data(string name, string address, int number, string city, string state, string email, bool agreed)
        {
            Name = name;
            Address = address;
            Number = number;
            City = city;
            State = state;
            Email = email;
            Agreed = agreed;
        }
    }
}

