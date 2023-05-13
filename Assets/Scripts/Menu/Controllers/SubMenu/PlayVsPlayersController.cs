using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Data;
using Gameplay.Services.TurnControllerStrategies;
using Menu.Data;
using Menu.Views.Icons;
using Menu.Views.SubMenuViews;
using Models;
using Services.SceneLoader;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Menu.Controllers
{
    public class PlayVsPlayersController : IInitializable, IDisposable
    {
        private readonly PlayVsPlayersView _playVsPlayersView;
        private readonly SceneLoader _sceneLoader;
        private readonly MenuData _menuData;
        private readonly GameplayVisualData _gameplayVisualData;
        private readonly MenuVisualData _menuVisualData;
        private readonly LevelSetupModel _levelSetupModel;

        private readonly List<PathIconView> _pathIcons = new List<PathIconView>();

        public PlayVsPlayersController(PlayVsPlayersView playVsPlayersView, SceneLoader sceneLoader, MenuData menuData,
            GameplayVisualData gameplayVisualData, MenuVisualData menuVisualData)
        {
            _playVsPlayersView = playVsPlayersView;
            _sceneLoader = sceneLoader;
            _menuData = menuData;
            _gameplayVisualData = gameplayVisualData;
            _menuVisualData = menuVisualData;
            _levelSetupModel = new LevelSetupModel();
        }

        void IInitializable.Initialize()
        {
            _playVsPlayersView.AddPlayerButton.onClick.AddListener(OpenAddPlayerView);

            _playVsPlayersView.AddPlayerView.SubmitButton.onClick.AddListener(AddPlayer);

            _playVsPlayersView.PlayButton.onClick.AddListener(() =>
            {
                _sceneLoader.LoadSceneWithEnqueuedBuilder(_menuData.GameplayScene, EnqueueLevelSetupModel).Forget();
            });

            SetupSelectPathMenu();
        }

        void IDisposable.Dispose()
        {
            _playVsPlayersView.PlayButton.onClick.RemoveAllListeners();
        }

        private void SetupSelectPathMenu()
        {
            foreach (var pathData in _gameplayVisualData.PathData)
            {
                var pathIconView = Object.Instantiate(_menuVisualData.PathIconView,
                    _playVsPlayersView.PathIconsToggleGroup.transform);

                _pathIcons.Add(pathIconView);

                pathIconView.Initialize(pathData.Icon);

                pathIconView.Toggle.onValueChanged.AddListener(isOn =>
                {
                    if (isOn)
                    {
                        _levelSetupModel.SelectedPathPrefab = pathData.Prefab;

                        foreach (var toggle in _pathIcons.Where(p => p != pathIconView).Select(p => p.Toggle))
                        {
                            toggle.isOn = false;
                        }
                    }
                });

                _playVsPlayersView.PathIconsToggleGroup.RegisterToggle(pathIconView.Toggle);
            }

            _playVsPlayersView.PathIconsToggleGroup.SetAllTogglesOff();

            _pathIcons.First().Toggle.isOn = true;
        }

        private void EnqueueLevelSetupModel(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levelSetupModel);
            builder.Register<PlayVsPlayersHandler>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void OpenAddPlayerView()
        {
            _playVsPlayersView.AddPlayerView.OpenAsync();
        }

        private void AddPlayer()
        {
            var playersName = _playVsPlayersView.AddPlayerView.InputField.text;

            var freePlayerView =
                _gameplayVisualData.PlayerViews.Except(_levelSetupModel.SelectedPlayerPrefabsByName.Values).First();

            _levelSetupModel.SelectedPlayerPrefabsByName.Add(playersName, freePlayerView);

            _playVsPlayersView.AddPlayerView.CloseAsync();

            _playVsPlayersView.AddPlayerView.InputField.text = "";

            var playerIcon = Object.Instantiate(_menuVisualData.PlayerIconView,
                _playVsPlayersView.AddedPlayersLayoutGroup.transform);

            playerIcon.SetName(playersName);
        }
    }
}