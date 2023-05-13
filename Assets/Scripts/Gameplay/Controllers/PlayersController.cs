using System;
using Cysharp.Threading.Tasks;
using Gameplay.Enums;
using Gameplay.Services;
using Gameplay.Services.TurnControllerStrategies.Interface;
using Models;
using VContainer.Unity;

namespace Controllers
{
    public class PlayersController : IStartable, IDisposable
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;
        private readonly IGameModeHandler _gameModeHandler;
        private readonly Action<int, MoveDirection> _onMovedAction;

        public PlayersController(LevelContainer levelContainer, LevelModel levelModel, IGameModeHandler gameModeHandler)
        {
            _levelContainer = levelContainer;
            _levelModel = levelModel;
            _gameModeHandler = gameModeHandler;
            _onMovedAction = (steps, direction) => { MovePlayerAsync(steps, direction).Forget(); };
        }

        void IStartable.Start()
        {
            foreach (var playerModel in _levelContainer.PlayerModels)
            {
                playerModel.OnMoveDistanceSet += _onMovedAction;
                playerModel.IsActive = true;
            }
        }

        void IDisposable.Dispose()
        {
            foreach (var playerModel in _levelContainer.PlayerViewsByModel.Keys)
            {
                playerModel.OnMoveDistanceSet -= _onMovedAction;
            }
        }

        private async UniTaskVoid MovePlayerAsync(int steps, MoveDirection moveDirection)
        {
            var playerModel = _levelModel.CurrentPlayer.Value;
            var playerView = _levelContainer.PlayerViewsByModel[playerModel];

            for (int i = 0; i < steps; i++)
            {
                var pathPointIndex = playerModel.CurrentProgress + (int) moveDirection;

                if (pathPointIndex >= _levelContainer.PathModel.TotalProgress)
                {
                    _levelModel.ChangeTurn();

                    return;
                }

                var pathPoint = _levelContainer.PathView.PathPoints[pathPointIndex];

                await playerView.PlayMoveToAnimationAsync(pathPoint.transform.position);

                playerModel.MovePlayer(moveDirection);
            }

            var lastPathPoint = _levelContainer.PathView.PathPoints[playerModel.CurrentProgress];

            if (_gameModeHandler.TryApplyPathPointEffect(lastPathPoint) == false)
            {
                _levelModel.ChangeTurn();
            }
        }
    }
}