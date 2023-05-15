using Gameplay.Models.Bot;
using Gameplay.Services.TurnControllerStrategies.Interface;
using Models;
using Views;
using Views.PathPointBehaviours;

namespace Gameplay.Services.TurnControllerStrategies
{
    public class PlayVsBotsHandler : IGameModeHandler
    {
        private readonly BotsContainer _botsContainer;
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;
        private readonly IBehaviorMapGenerator _behaviorMapGenerator;

        public PlayVsBotsHandler(BotsContainer botsContainer, LevelContainer levelContainer, LevelModel levelModel,
            IBehaviorMapGenerator behaviorMapGenerator)
        {
            _botsContainer = botsContainer;
            _levelContainer = levelContainer;
            _levelModel = levelModel;
            _behaviorMapGenerator = behaviorMapGenerator;
        }

        void IGameModeHandler.OnTurnChanged()
        {
            if (_levelModel.CurrentPlayer.Value is BotModel)
            {
                var moveLenght = _levelModel.RandomMoveLenght();

                var botModel = (BotModel) _levelModel.CurrentPlayer.Value;

                botModel.SetMoveDistance(1);
            }
            else
            {
                _levelContainer.GameUIView.SetMakeMoveButtonInteractable(true);
            }
        }

        void IGameModeHandler.OnMoveButtonClicked()
        {
            var moveLenght = _levelModel.RandomMoveLenght();

            var playerModel = _levelModel.CurrentPlayer.Value;

            playerModel.SetMoveDistance(1);

            _levelContainer.GameUIView.SetMakeMoveButtonInteractable(false);
        }

        bool IGameModeHandler.TryApplyPathPointEffect(PathPointView pathPointView)
        {
            var containsTask = _levelContainer.PathModel.TaskedPathPointViews.Contains(pathPointView);

            if (containsTask)
            {
                var task = _behaviorMapGenerator.GeneratePathPointBehaviour();

                if (_levelModel.CurrentPlayer.Value is BotModel botModel)
                {
                    task.ApplyEffectToBot(botModel);
                }
                else
                {
                    task.ApplyEffectToPlayer(_levelModel.CurrentPlayer.Value);
                }
            }

            return containsTask;
        }
    }
}