using Menu.Views.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views.SubMenuViews
{
    public class AddPlayerView : BaseMenuView
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _submitButton;

        public Button SubmitButton => _submitButton;
        public TMP_InputField InputField => _inputField;
    }
}