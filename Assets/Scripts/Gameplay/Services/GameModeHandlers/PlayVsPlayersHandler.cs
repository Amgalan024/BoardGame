using Gameplay.Services.TurnControllerStrategies.Interface;
using Models;
using Views;
using Views.PathPointBehaviours;

namespace Gameplay.Services.TurnControllerStrategies
{
    public class PlayVsPlayersHandler : IGameModeHandler
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;
        private readonly IBehaviorMapGenerator _behaviorMapGenerator;

        public PlayVsPlayersHandler(LevelContainer levelContainer, LevelModel levelModel,
            IBehaviorMapGenerator behaviorMapGenerator)
        {
            _levelContainer = levelContainer;
            _levelModel = levelModel;
            _behaviorMapGenerator = behaviorMapGenerator;
        }

        void IGameModeHandler.OnTurnChanged()
        {
            _levelContainer.GameUIView.SetMakeMoveButtonInteractable(true);
        }

        void IGameModeHandler.OnMoveButtonClicked()
        {
            var moveLenght = _levelModel.RandomMoveLenght();

            var playerModel = _levelModel.CurrentPlayer.Value;

            playerModel.SetMoveDistance(moveLenght);

            _levelContainer.GameUIView.SetMakeMoveButtonInteractable(false);
        }

        bool IGameModeHandler.TryApplyPathPointEffect(PathPointView pathPointView)
        {
            var containsTask = _levelContainer.PathModel.TaskedPathPointViews.Contains(pathPointView);

            if (containsTask)
            {
                var task = _behaviorMapGenerator.GeneratePathPointBehaviour();

                task.ApplyEffectToPlayer(_levelModel.CurrentPlayer.Value);
            }

            return containsTask;
        }
    }
}