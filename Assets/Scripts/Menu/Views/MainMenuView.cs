using Menu.Views.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views
{
    public class MainMenuView : BaseMenuView
    {
        [SerializeField] private Button _vsBotsButton;
        [SerializeField] private Button _vsPlayersButton;
        [SerializeField] private Button _settings;
        
        public Button VSBotsButton => _vsBotsButton;
        public Button VsPlayersButton => _vsPlayersButton;
        public Button Settings => _settings;
    }
}