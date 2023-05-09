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

        public MainMenuController(MenuData menuData, SceneLoader sceneLoader, MainMenuView mainMenuView,
            PlayVsPlayersView playVsPlayersView)
        {
            _menuData = menuData;
            _sceneLoader = sceneLoader;
            _mainMenuView = mainMenuView;
            _playVsPlayersView = playVsPlayersView;
        }

        void IInitializable.Initialize()
        {
            _mainMenuView.VsPlayersButton.onClick.AddListener(() =>
            {
                _mainMenuView.Close();
                _playVsPlayersView.Open();
            });
        }
    }
}