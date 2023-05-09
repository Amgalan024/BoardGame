using Gameplay.Services;
using Gameplay.Services.Path;
using Models;
using VContainer.Unity;

namespace Controllers
{
    public class LevelSetupController : IInitializable
    {
        private readonly LevelFactory _levelFactory;
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;

        public LevelSetupController(LevelFactory levelFactory, LevelContainer levelContainer, LevelModel levelModel)
        {
            _levelFactory = levelFactory;
            _levelContainer = levelContainer;
            _levelModel = levelModel;
        }

        void IInitializable.Initialize()
        {
            _levelFactory.CreatePath();
            _levelFactory.CreatePlayers();
            _levelFactory.CreateUI();

            _levelModel.SetActivePlayers(_levelContainer.PlayerModels);

            foreach (var playerView in _levelContainer.PlayerViewsByModel.Values)
            {
                playerView.SetPosition(_levelContainer.PathView.StartPathPoint.transform.position);
            }
        }
    }
}