using System;
using Gameplay.Services;
using Models;

namespace Controllers
{
    public class UIController : IDisposable
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;

        public UIController(LevelContainer levelContainer, LevelModel levelModel)
        {
            _levelContainer = levelContainer;
            _levelModel = levelModel;
        }

        void IDisposable.Dispose()
        {
            _levelContainer.GameUIView.MakeMoveButton.onClick.RemoveAllListeners();
        }

        public void SetupUILogic()
        {
            _levelModel.CurrentPlayer = _levelContainer.LinkedPlayerModels.First;

            _levelContainer.GameUIView.MakeMoveButton.onClick.AddListener(MakeMove);
        }

        private void MakeMove()
        {
            var moveLenght = _levelModel.RandomMoveLenght();

            _levelModel.CurrentPlayer.Value.CurrentProgress.Value += moveLenght;

            if (_levelModel.CurrentPlayer.Next != null)
            {
                _levelModel.CurrentPlayer = _levelModel.CurrentPlayer.Next;
            }
        }
    }
}