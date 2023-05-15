using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Data;
using Gameplay.Enums;
using Gameplay.Models.Bot;
using Gameplay.Services;
using Gameplay.Services.TurnControllerStrategies;
using Menu.Data;
using Menu.Views.Icons;
using Menu.Views.SubMenuViews;
using Models;
using Services.SceneLoader;
using TMPro;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Menu.Controllers
{
    public class PlayVsBotsController : IInitializable, IDisposable
    {
        private readonly PlayVsBotsView _playVsBotsView;
        private readonly SceneLoader _sceneLoader;
        private readonly MenuData _menuData;
        private readonly GameplayVisualData _gameplayVisualData;
        private readonly MenuVisualData _menuVisualData;

        private readonly LevelSetupModel _levelSetupModel = new LevelSetupModel();
        private readonly List<PathIconView> _pathIcons = new List<PathIconView>();
        private readonly BotsContainer _botsContainer = new BotsContainer();

        private readonly Dictionary<TMP_Dropdown.OptionData, BotsDifficultyTypes> _botsDifficultyByOption =
            new Dictionary<TMP_Dropdown.OptionData, BotsDifficultyTypes>();

        public PlayVsBotsController(PlayVsBotsView playVsBotsView, SceneLoader sceneLoader, MenuData menuData,
            GameplayVisualData gameplayVisualData, MenuVisualData menuVisualData)
        {
            _playVsBotsView = playVsBotsView;
            _sceneLoader = sceneLoader;
            _menuData = menuData;
            _gameplayVisualData = gameplayVisualData;
            _menuVisualData = menuVisualData;
        }

        void IInitializable.Initialize()
        {
            _playVsBotsView.AddBotButton.onClick.AddListener(OpenAddBotView);

            _playVsBotsView.AddBotView.SubmitButton.onClick.AddListener(AddBot);

            _playVsBotsView.PlayButton.onClick.AddListener(() =>
            {
                _sceneLoader.LoadSceneWithEnqueuedBuilder(_menuData.GameplayScene, EnqueueLevelSetupModel).Forget();
            });

            SetupSelectPathMenu();
            SetupBotsDifficultyDropdown();

            AddPlayer();
        }

        void IDisposable.Dispose()
        {
        }

        private void SetupBotsDifficultyDropdown()
        {
            foreach (var botDifficultyConfig in _menuData.BotDifficultyConfigs)
            {
                var option = new TMP_Dropdown.OptionData(botDifficultyConfig.DropDownText);

                _playVsBotsView.AddBotView.DifficultyDropdown.options.Add(option);

                _botsDifficultyByOption.Add(option, botDifficultyConfig.BotsDifficultyType);
            }
        }

        private void SetupSelectPathMenu()
        {
            foreach (var pathData in _gameplayVisualData.PathData)
            {
                var pathIconView = Object.Instantiate(_menuVisualData.PathIconView,
                    _playVsBotsView.PathIconsToggleGroup.transform);

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

                _playVsBotsView.PathIconsToggleGroup.RegisterToggle(pathIconView.Toggle);
            }

            _playVsBotsView.PathIconsToggleGroup.SetAllTogglesOff();

            _pathIcons.First().Toggle.isOn = true;
        }

        private void EnqueueLevelSetupModel(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levelSetupModel);
            builder.RegisterInstance(_botsContainer);
            builder.Register<PlayVsBotsHandler>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void AddPlayer()
        {
            var playersName = "Вы";
            var playerModel = new PlayerModel(playersName);

            var freePlayerViewData =
                _gameplayVisualData.PlayerViewData
                    .Except(_levelSetupModel.PlayerViewDataByModels.Values).First();

            _levelSetupModel.PlayerViewDataByModels.Add(playerModel, freePlayerViewData);

            var playerIcon = Object.Instantiate(_menuVisualData.PlayerIconView,
                _playVsBotsView.AddedPlayersLayoutGroup.transform);

            playerIcon.SetName(playersName);
            playerIcon.SetIcon(freePlayerViewData.Icon);
        }

        private void AddBot()
        {
            var botName = "Bot №" + _levelSetupModel.PlayerViewDataByModels.Count;

            var difficultyDropDownValue = _playVsBotsView.AddBotView.DifficultyDropdown.value;
            var difficultyDropDownOption =
                _playVsBotsView.AddBotView.DifficultyDropdown.options[difficultyDropDownValue];

            var botDifficulty = _botsDifficultyByOption[difficultyDropDownOption];

            var botModel = new BotModel(botName, botDifficulty);

            var freePlayerViewData =
                _gameplayVisualData.PlayerViewData
                    .Except(_levelSetupModel.PlayerViewDataByModels.Values)
                    .First();

            _levelSetupModel.PlayerViewDataByModels.Add(botModel, freePlayerViewData);

            _playVsBotsView.AddBotView.CloseAsync();

            var playerIcon = Object.Instantiate(_menuVisualData.PlayerIconView,
                _playVsBotsView.AddedPlayersLayoutGroup.transform);

            playerIcon.SetName(botName);
            playerIcon.SetIcon(freePlayerViewData.Icon);
        }

        private void OpenAddBotView()
        {
            _playVsBotsView.AddBotView.OpenAsync().Forget();
        }
    }
}