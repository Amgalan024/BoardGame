using Gameplay.Services;
using Zenject;

namespace Controllers
{
    public class LevelSetupController : IInitializable
    {
        private readonly LevelFactory _levelFactory;
        private readonly LevelContainer _levelContainer;
        private readonly DiContainer _container;

        public LevelSetupController(LevelFactory levelFactory, LevelContainer levelContainer, DiContainer container)
        {
            _levelFactory = levelFactory;
            _levelContainer = levelContainer;
            _container = container;
        }

        void IInitializable.Initialize()
        {
            CreateLevel();
            CreateLogicContainer();
        }

        private void CreateLevel()
        {
            _levelFactory.CreatePlayers();
            _levelFactory.CreatePath();
            _levelFactory.CreateUI();

            foreach (var playerView in _levelContainer.PlayerViewsByModel.Values)
            {
                playerView.SetPosition(_levelContainer.PathView.StartPathPoint.transform.position);
            }
        }

        private void CreateLogicContainer()
        {
            var subContainer = _container.CreateSubContainer();

            subContainer.BindInterfacesTo<UIController>().AsSingle();
            subContainer.BindInterfacesTo<PlayerController>().AsSingle();
        }
    }
}