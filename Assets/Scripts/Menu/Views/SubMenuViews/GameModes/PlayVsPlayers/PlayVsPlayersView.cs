using Menu.Views.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views.SubMenuViews
{
    public class PlayVsPlayersView : BaseMenuView
    {
        [SerializeField] private Button _addPlayerButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private ToggleGroup _pathIconsToggleGroup;
        [SerializeField] private LayoutGroup _addedPlayersLayoutGroup;
        [SerializeField] private AddPlayerView _addPlayerView;

        public Button AddPlayerButton => _addPlayerButton;
        public Button PlayButton => _playButton;
        public ToggleGroup PathIconsToggleGroup => _pathIconsToggleGroup;
        public LayoutGroup AddedPlayersLayoutGroup => _addedPlayersLayoutGroup;
        public AddPlayerView AddPlayerView => _addPlayerView;
    }
}