using Gameplay.Services;
using Gameplay.Services.Path;
using Models;
using VContainer.Unity;
using Views.PathPointBehaviours;

namespace Controllers
{
    public class LevelSetupController : IInitializable
    {
        private readonly LevelFactory _levelFactory;
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;
        private readonly IBehaviorMapGenerator _behaviorMapGenerator;

        public LevelSetupController(LevelFactory levelFactory, LevelContainer levelContainer, LevelModel levelModel,
            IBehaviorMapGenerator behaviorMapGenerator)
        {
            _levelFactory = levelFactory;
            _levelContainer = levelContainer;
            _levelModel = levelModel;
            _behaviorMapGenerator = behaviorMapGenerator;
        }

        void IInitializable.Initialize()
        {
            _levelFactory.CreatePath();
            _levelFactory.CreatePlayers();
            _levelFactory.CreateUI();

            _levelModel.SetActivePlayers(_levelContainer.PlayerModels);
            _levelContainer.PathModel.TaskedPathPointViews.AddRange(_behaviorMapGenerator.GenerateBehavioursMap());

            foreach (var playerView in _levelContainer.PlayerViewsByModel.Values)
            {
                playerView.SetPosition(_levelContainer.PathView.StartPathPoint.transform.position);
            }
        }
    }
}