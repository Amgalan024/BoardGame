using Cysharp.Threading.Tasks;
using Menu.Data;
using Menu.Views;
using Services.SceneLoader;
using VContainer.Unity;

namespace Menu.Controllers
{
    public class MenuController : IInitializable
    {
        private readonly MenuData _menuData;
        private readonly SceneLoader _sceneLoader;
        private readonly MenuView _menuView;

        public MenuController(MenuData menuData, SceneLoader sceneLoader, MenuView menuView)
        {
            _menuData = menuData;
            _sceneLoader = sceneLoader;
            _menuView = menuView;
        }

        void IInitializable.Initialize()
        {
            _menuView.StartButton.onClick.AddListener(() =>
            {
                _sceneLoader.LoadSceneAsync(_menuData.GameplayScene).Forget();
            });
        }
    }
}