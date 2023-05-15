using Data;
using Menu.Data;
using Menu.Views;
using Menu.Views.SubMenuViews;
using Services.SceneLoader;
using VContainer.Unity;

namespace Menu.Controllers
{
    public class MainMenuController : IInitializable
    {
        private readonly MenuData _menuData;
        private readonly SceneLoader _sceneLoader;
        private readonly MainMenuView _mainMenuView;
        private readonly PlayVsPlayersView _playVsPlayersView;
        private readonly PlayVsBotsView _playVsBotsView;

        public MainMenuController(MenuData menuData, SceneLoader sceneLoader, MainMenuView mainMenuView,
            PlayVsPlayersView playVsPlayersView, PlayVsBotsView playVsBotsView)
        {
            _menuData = menuData;
            _sceneLoader = sceneLoader;
            _mainMenuView = mainMenuView;
            _playVsPlayersView = playVsPlayersView;
            _playVsBotsView = playVsBotsView;
        }

        void IInitializable.Initialize()
        {
            _mainMenuView.VsPlayersButton.onClick.AddListener(() =>
            {
                _mainMenuView.CloseAsync();
                _playVsPlayersView.OpenAsync();
            });

            _mainMenuView.VSBotsButton.onClick.AddListener(() =>
            {
                _mainMenuView.CloseAsync();
                _playVsBotsView.OpenAsync();
            });
        }
    }
}