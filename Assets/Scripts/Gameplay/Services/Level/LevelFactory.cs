using Data;
using Gameplay.Services.Path;
using Models;
using UnityEngine;
using VContainer.Unity;

namespace Gameplay.Services
{
    public class LevelFactory
    {
        private readonly LevelSetupModel _levelSetupModel;
        private readonly LevelContainer _levelContainer;
        private readonly GameplayVisualData _visualData;

        private Transform _parentScope;

        public LevelFactory(LevelSetupModel levelSetupModel, LevelContainer levelContainer,
            GameplayVisualData visualData, LifetimeScope lifetimeScope)
        {
            _levelSetupModel = levelSetupModel;
            _levelContainer = levelContainer;
            _visualData = visualData;

            _parentScope = lifetimeScope.transform;
        }

        public void CreatePlayers()
        {
            foreach (var selectedPlayer in _levelSetupModel.SelectedPlayerPrefabsByName)
            {
                var playerModel = new PlayerModel(_levelContainer.PathModel.TotalProgress, selectedPlayer.Key);
                var playerView = Object.Instantiate(selectedPlayer.Value, _parentScope);

                _levelContainer.PlayerViewsByModel.Add(playerModel, playerView);
            }
        }

        public void CreatePath()
        {
            var pathView = Object.Instantiate(_levelSetupModel.SelectedPathPrefab, _parentScope);

            var pathPointCount = pathView.PathPoints.Length;

            var pathModel = new PathModel(pathPointCount);

            _levelContainer.PathModel = pathModel;
            _levelContainer.PathView = pathView;
        }

        public void CreateUI()
        {
            var gameUIView = Object.Instantiate(_visualData.GameUIView, _parentScope);
            var mathTaskView = Object.Instantiate(_visualData.MathMathTaskView, _parentScope);
            _levelContainer.GameUIView = gameUIView;
            _levelContainer.MathTaskView = mathTaskView;
        }
    }
}