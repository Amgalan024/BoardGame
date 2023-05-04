using Zenject;

namespace Controllers
{
    public class GameplayStartup : IInitializable
    {
        private readonly LevelSetupController _levelSetupController;
        private readonly PlayersController _playersController;

        public GameplayStartup(LevelSetupController levelSetupController, PlayersController playersController)
        {
            _levelSetupController = levelSetupController;
            _playersController = playersController;
        }

        void IInitializable.Initialize()
        {
            _levelSetupController.SetupLevel();
            _playersController.SetupPlayers();
        }
    }
}