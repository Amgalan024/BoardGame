using System;
using Cysharp.Threading.Tasks;
using Gameplay.Enums;
using Gameplay.Services;
using Models;
using VContainer.Unity;
using Views;
using Views.PathPointBehaviours;

namespace Controllers
{
    public class PlayersController : IStartable, IDisposable
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;

        private readonly Action<int, MoveDirection> _onMovedAction;

        public PlayersController(LevelContainer levelContainer, LevelModel levelModel)
        {
            _levelContainer = levelContainer;
            _levelModel = levelModel;
            _onMovedAction = (steps, direction) => { MovePlayerAsync(steps, direction).Forget(); };
        }

        void IStartable.Start()
        {
            foreach (var playerModel in _levelContainer.PlayerModels)
            {
                playerModel.OnMoveDistanceSet += _onMovedAction;
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

            for (int i = playerModel.CurrentProgress; i < steps; i++)
            {
                var pathPoint = _levelContainer.PathView.PathPoints[i];

                await playerView.PlayMoveToAnimationAsync(pathPoint.transform.position);

                playerModel.MovePlayer(moveDirection);
            }

            var lastPathPoint = _levelContainer.PathView.PathPoints[playerModel.CurrentProgress];

            if (TryApplyPathPointEffect(lastPathPoint) == false)
            {
                _levelModel.ChangeTurn();
            }
        }

        private bool TryApplyPathPointEffect(PathPointView pathPointView)
        {
            var hasBehaviour = _levelContainer.PathModel.PathPointBehaviours.TryGetValue(pathPointView,
                out IPathPointBehaviour pathPointBehaviour);

            pathPointBehaviour?.ApplyEffect(_levelModel.CurrentPlayer.Value);

            return hasBehaviour;
        }
    }
}