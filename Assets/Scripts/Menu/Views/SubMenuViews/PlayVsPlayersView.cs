using Menu.Views.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views.SubMenuViews
{
    public class PlayVsPlayersView : BaseMenuView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private TMP_InputField _numberOfPlayersInputField;
        [SerializeField] private ToggleGroup _pathIconsToggleGroup;

        public Button PlayButton => _playButton;
        public TMP_InputField NumberOfPlayersInputField => _numberOfPlayersInputField;
        public ToggleGroup PathIconsToggleGroup => _pathIconsToggleGroup;
    }
}