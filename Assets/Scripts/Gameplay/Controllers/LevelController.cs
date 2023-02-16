using Gameplay.Services;

namespace Controllers
{
    public class LevelController
    {
        private readonly LevelFactory _levelFactory;
        private readonly LevelContainer _levelContainer;

        public LevelController(LevelFactory levelFactory, LevelContainer levelContainer)
        {
            _levelFactory = levelFactory;
            _levelContainer = levelContainer;
        }

        public void CreateLevel()
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