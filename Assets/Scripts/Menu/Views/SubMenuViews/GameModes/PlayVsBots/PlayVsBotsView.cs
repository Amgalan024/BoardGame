using Menu.Views.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views.SubMenuViews
{
    public class PlayVsBotsView : BaseMenuView
    {
        [SerializeField] private Button _addBotButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private ToggleGroup _pathIconsToggleGroup;
        [SerializeField] private LayoutGroup _addedPlayersLayoutGroup;
        [SerializeField] private AddBotView _addBotView;

        public Button AddBotButton => _addBotButton;
        public Button PlayButton => _playButton;
        public ToggleGroup PathIconsToggleGroup => _pathIconsToggleGroup;
        public LayoutGroup AddedPlayersLayoutGroup => _addedPlayersLayoutGroup;
        public AddBotView AddBotView => _addBotView;
    }
}