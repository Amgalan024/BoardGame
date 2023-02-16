using System;
using Cysharp.Threading.Tasks;
using Gameplay.Services;
using UniRx;

namespace Controllers
{
    public class PlayersController : IDisposable
    {
        private readonly LevelContainer _levelContainer;

        public PlayersController(LevelContainer levelContainer)
        {
            _levelContainer = levelContainer;
        }

        void IDisposable.Dispose()
        {
            foreach (var playerModel in _levelContainer.PlayerViewsByModel.Keys)
            {
                playerModel.CurrentProgress.Dispose();
            }
        }

        public void SetupPlayers()
        {
            foreach (var playerViewByModel in _levelContainer.PlayerViewsByModel)
            {
                var playerModel = playerViewByModel.Key;
                var playerView = playerViewByModel.Value;

                playerModel.CurrentProgress.Subscribe(_ =>
                {
                    var pathPoint = _levelContainer.PathView.PathPoints[playerModel.CurrentProgress.Value];

                    playerView.PlayMoveToAnimationAsync(pathPoint.transform.position).Forget();
                });
            }
        }
    }
}