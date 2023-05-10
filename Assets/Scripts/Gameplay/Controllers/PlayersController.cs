using System;
using Cysharp.Threading.Tasks;
using Gameplay.Enums;
using Gameplay.Services;
using Gameplay.Services.Path;
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
        private readonly IBehaviorMapGenerator _behaviorMapGenerator;

        private readonly Action<int, MoveDirection> _onMovedAction;

        public PlayersController(LevelContainer levelContainer, LevelModel levelModel,
            IBehaviorMapGenerator behaviorMapGenerator)
        {
            _levelContainer = levelContainer;
            _levelModel = levelModel;
            _behaviorMapGenerator = behaviorMapGenerator;
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

                var pathPoint = _levelContainer.PathView.PathPoints[pathPointIndex];

                await playerView.PlayMoveToAnimationAsync(pathPoint.transform.position);

                playerModel.MovePlayer(moveDirection);

                if (pathPointIndex >= _levelContainer.PathModel.TotalProgress)
                {
                    _levelModel.ChangeTurn();

                    return;
                }
            }

            var lastPathPoint = _levelContainer.PathView.PathPoints[playerModel.CurrentProgress];

            if (TryApplyPathPointEffect(lastPathPoint) == false)
            {
                _levelModel.ChangeTurn();
            }
        }

        private bool TryApplyPathPointEffect(PathPointView pathPointView)
        {
            var containsTask = _levelContainer.PathModel.TaskedPathPointViews.Contains(pathPointView);

            if (containsTask)
            {
                var task = _behaviorMapGenerator.GeneratePathPointBehaviour();

                task.ApplyEffect(_levelModel.CurrentPlayer.Value);
            }

            return containsTask;
        }
    }
}