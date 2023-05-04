using System;
using Cysharp.Threading.Tasks;
using Gameplay.Services;
using Models;
using UnityEngine;
using Views;
using Views.PathPointBehaviours;

namespace Controllers
{
    public class PlayersController : IDisposable
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;

        public PlayersController(LevelContainer levelContainer, LevelModel levelModel)
        {
            _levelContainer = levelContainer;
            _levelModel = levelModel;
        }

        void IDisposable.Dispose()
        {
            foreach (var playerModel in _levelContainer.PlayerViewsByModel.Keys)
            {
                playerModel.OnMoved -= MovePlayer;
            }

            _levelContainer.GameUIView.MakeMoveButton.onClick.RemoveAllListeners();
        }

        public void SetupPlayers()
        {
            foreach (var playerModel in _levelContainer.LinkedPlayerModels)
            {
                playerModel.OnMoved += MovePlayer;
            }

            _levelModel.CurrentPlayer = _levelContainer.LinkedPlayerModels.First;

            _levelContainer.GameUIView.MakeMoveButton.onClick.AddListener(OnMoveButtonClicked);
        }

        //todo: переместить в UI Controller
        private void OnMoveButtonClicked()
        {
            var moveLenght = _levelModel.RandomMoveLenght();

            var playerModel = _levelModel.CurrentPlayer.Value;

            playerModel.MovePlayer(moveLenght);
        }

        private void MovePlayer(int steps)
        {
            var playerModel = _levelModel.CurrentPlayer.Value;

            var pathPoint = _levelContainer.PathView.PathPoints[playerModel.CurrentProgress];

            _levelContainer.PlayerViewsByModel[playerModel].PlayMoveToAnimationAsync(pathPoint.transform.position)
                .Forget();

            ApplyPathPointEffect(pathPoint);

            if (_levelModel.CurrentPlayer.Next != null)
            {
                _levelModel.CurrentPlayer = _levelModel.CurrentPlayer.Next;
            }
        }

        private void ApplyPathPointEffect(PathPointView pathPointView)
        {
            var behaviour = pathPointView.GetComponent<IPathPointBehaviour>();

            behaviour.ApplyEffect(_levelModel.CurrentPlayer.Value);
        }
    }
}