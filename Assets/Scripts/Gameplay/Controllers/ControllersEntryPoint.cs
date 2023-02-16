using Zenject;

namespace Controllers
{
    public class ControllersEntryPoint : IInitializable
    {
        private readonly LevelController _levelController;
        private readonly PlayersController _playersController;
        private readonly UIController _uiController;

        public ControllersEntryPoint(LevelController levelController, PlayersController playersController, UIController uiController)
        {
            _levelController = levelController;
            _playersController = playersController;
            _uiController = uiController;
        }

        void IInitializable.Initialize()
        {
            _levelController.CreateLevel();
            _playersController.SetupPlayers();
            _uiController.SetupUILogic();
        }
    }
}