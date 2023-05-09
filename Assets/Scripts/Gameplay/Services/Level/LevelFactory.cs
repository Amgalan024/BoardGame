using Data;
using Gameplay.Services.Path;
using Models;
using UnityEngine;

namespace Gameplay.Services
{
    public class LevelFactory
    {
        private readonly LevelSetupModel _levelSetupModel;
        private readonly LevelContainer _levelContainer;
        private readonly GameplayVisualData _visualData;
        private readonly MathTaskGenerator _mathTaskGenerator;

        public LevelFactory(LevelSetupModel levelSetupModel, LevelContainer levelContainer,
            GameplayVisualData visualData, MathTaskGenerator mathTaskGenerator)
        {
            _levelSetupModel = levelSetupModel;
            _levelContainer = levelContainer;
            _visualData = visualData;
            _mathTaskGenerator = mathTaskGenerator;
        }

        public void CreatePlayers()
        {
            foreach (var selectedPlayerPrefab in _levelSetupModel.SelectedPlayerPrefabs)
            {
                var playerModel = new PlayerModel(_levelContainer.PathModel.TotalProgress);
                var playerView = Object.Instantiate(selectedPlayerPrefab);

                _levelContainer.PlayerViewsByModel.Add(playerModel, playerView);
            }
        }

        public void CreatePath()
        {
            var pathView = Object.Instantiate(_levelSetupModel.SelectedPathPrefab);

            var pathPointCount = pathView.PathPoints.Length;

            var pathModel = new PathModel(pathPointCount);

            _levelContainer.PathModel = pathModel;
            _levelContainer.PathView = pathView;

            _mathTaskGenerator.GenerateTasks();
        }

        public void CreateUI()
        {
            var gameUIView = Object.Instantiate(_visualData.GameUIView);
            var mathTaskView = Object.Instantiate(_visualData.MathMathTaskView);
            _levelContainer.GameUIView = gameUIView;
            _levelContainer.MathTaskView = mathTaskView;
        }
    }
}