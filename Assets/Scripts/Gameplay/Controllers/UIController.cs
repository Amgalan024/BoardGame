using System;
using Gameplay.Services;
using Models;
using Zenject;

namespace Controllers
{
    public class UIController : IInitializable, IDisposable
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;

        public UIController(LevelContainer levelContainer, LevelModel levelModel)
        {
            _levelContainer = levelContainer;
            _levelModel = levelModel;
        }

        void IInitializable.Initialize()
        {
            SetupLogic();
        }

        void IDisposable.Dispose()
        {
            _levelContainer.GameUIView.MakeMoveButton.onClick.RemoveAllListeners();
        }

        private void SetupLogic()
        {
            _levelContainer.GameUIView.MakeMoveButton.onClick.AddListener(() =>
            {
                var moveLenght = _levelModel.RandomMoveLenght();

                _levelModel.CurrentPlayer.CurrentProgress.Value += moveLenght;
            });
        }
    }
}