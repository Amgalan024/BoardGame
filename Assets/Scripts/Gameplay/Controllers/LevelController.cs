using System;
using Gameplay.Services;
using Gameplay.Services.TurnControllerStrategies.Interface;
using Models;
using VContainer.Unity;

namespace Controllers
{
    public class LevelController : IStartable, IDisposable
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;
        private readonly IGameModeHandler _gameModeHandler;

        public LevelController(LevelModel levelModel, LevelContainer levelContainer, IGameModeHandler gameModeHandler)
        {
            _levelModel = levelModel;
            _levelContainer = levelContainer;
            _gameModeHandler = gameModeHandler;
        }

        void IStartable.Start()
        {
            _levelContainer.MathTaskView.CloseAsync();

            _levelContainer.GameUIView.MakeMoveButton.onClick.AddListener(_gameModeHandler.OnMoveButtonClicked);
            _levelModel.TurnChanged += _gameModeHandler.OnTurnChanged;
        }

        void IDisposable.Dispose()
        {
            _levelContainer.GameUIView.MakeMoveButton.onClick.RemoveAllListeners();
            _levelModel.TurnChanged -= _gameModeHandler.OnTurnChanged;
        }
    }
}