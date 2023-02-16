using Models;
using UnityEngine;

namespace Gameplay.Services
{
    public class LevelFactory
    {
        private readonly LevelSetupModel _levelSetupModel;
        private readonly LevelContainer _levelContainer;

        public LevelFactory(LevelSetupModel levelSetupModel, LevelContainer levelContainer)
        {
            _levelSetupModel = levelSetupModel;
            _levelContainer = levelContainer;
        }

        public void CreatePlayers()
        {
            foreach (var selectedPlayerPrefab in _levelSetupModel.SelectedPlayerPrefabs)
            {
                var playerModel = new PlayerModel();
                var playerView = Object.Instantiate(selectedPlayerPrefab);

                _levelContainer.PlayerViewsByModel.Add(playerModel, playerView);
                _levelContainer.LinkedPlayerModels.AddLast(playerModel);
            }
        }

        public void CreatePath()
        {
            var pathView = Object.Instantiate(_levelSetupModel.SelectedPathPrefab);

            var pathPointCount = pathView.PathPoints.Length;

            var pathModel = new PathModel(pathPointCount);

            _levelContainer.PathModel = pathModel;
            _levelContainer.PathView = pathView;
        }

        public void CreateUI()
        {
            var gameUIView = Object.Instantiate(_levelSetupModel.GameUIView);
            _levelContainer.GameUIView = gameUIView;
        }
    }
}