using System;
using Gameplay.Services;
using Models;
using VContainer.Unity;

namespace Controllers
{
    public class GameplayUIController : IInitializable, IDisposable
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;

        public GameplayUIController(LevelModel levelModel, LevelContainer levelContainer)
        {
            _levelModel = levelModel;
            _levelContainer = levelContainer;
        }

        void IInitializable.Initialize()
        {
            _levelContainer.GameUIView.MakeMoveButton.onClick.AddListener(OnMoveButtonClicked);
        }

        void IDisposable.Dispose()
        {
            _levelContainer.GameUIView.MakeMoveButton.onClick.RemoveAllListeners();
        }

        private void OnMoveButtonClicked()
        {
            var moveLenght = _levelModel.RandomMoveLenght();

            var playerModel = _levelModel.CurrentPlayer.Value;

            playerModel.SetMoveDistance(1);
        }
    }
}