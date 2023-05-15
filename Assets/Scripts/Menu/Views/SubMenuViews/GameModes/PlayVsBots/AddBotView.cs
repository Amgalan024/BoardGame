using Menu.Views.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views.SubMenuViews
{
    public class AddBotView : BaseMenuView
    {
        [SerializeField] private TMP_Dropdown _difficultyDropdown;
        [SerializeField] private Button _submitButton;

        public TMP_Dropdown DifficultyDropdown => _difficultyDropdown;
        public Button SubmitButton => _submitButton;
    }
}