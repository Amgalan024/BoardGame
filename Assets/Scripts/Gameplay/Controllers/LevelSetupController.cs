using Gameplay.Services;
using Services.SceneLoader;

namespace Controllers
{
    public class LevelSetupController
    {
        private readonly LevelFactory _levelFactory;
        private readonly LevelContainer _levelContainer;

        public LevelSetupController(LevelFactory levelFactory, LevelContainer levelContainer)
        {
            _levelFactory = levelFactory;
            _levelContainer = levelContainer;
        }

        public void SetupLevel()
        {
            _levelFactory.CreatePlayers();
            _levelFactory.CreatePath();
            _levelFactory.CreateUI();

            foreach (var playerView in _levelContainer.PlayerViewsByModel.Values)
            {
                playerView.SetPosition(_levelContainer.PathView.StartPathPoint.transform.position);
            }
        }
    }
}