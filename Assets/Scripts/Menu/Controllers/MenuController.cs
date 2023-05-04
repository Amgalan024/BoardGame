using System.Linq;
using Cysharp.Threading.Tasks;
using Data;
using Menu.Data;
using Menu.Views;
using Models;
using Services.SceneLoader;
using VContainer;
using VContainer.Unity;

namespace Menu.Controllers
{
    public class MenuController : IInitializable
    {
        private readonly MenuData _menuData;
        private readonly SceneLoader _sceneLoader;
        private readonly MenuView _menuView;
        private readonly GameplayVisualData _gameplayVisualData;

        public MenuController(MenuData menuData, SceneLoader sceneLoader, MenuView menuView,
            GameplayVisualData gameplayVisualData)
        {
            _menuData = menuData;
            _sceneLoader = sceneLoader;
            _menuView = menuView;
            _gameplayVisualData = gameplayVisualData;
        }

        void IInitializable.Initialize()
        {
            _menuView.StartButton.onClick.AddListener(() =>
            {
                _sceneLoader.LoadSceneWithEnqueuedBuilder(_menuData.GameplayScene, EnqueueLevelSetupModel).Forget();
            });
        }

        private void EnqueueLevelSetupModel(IContainerBuilder builder)
        {
            var levelSetupModel = new LevelSetupModel
            {
                SelectedPathPrefab = _gameplayVisualData.PathViews.First(),
                GameUIView = _gameplayVisualData.GameUIViews.First(),
                SelectedPlayerPrefabs = _gameplayVisualData.PlayerViews
            };

            builder.RegisterInstance(levelSetupModel);
        }
    }
}