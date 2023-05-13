using Gameplay.Services.TurnControllerStrategies.Interface;
using Models;
using UnityEngine;
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
            if (_botsContainer.BotsIdList.Contains(_levelModel.CurrentPlayer.Value.Name))
            {
                var moveLenght = _levelModel.RandomMoveLenght();

                var playerModel = _levelModel.CurrentPlayer.Value;

                playerModel.SetMoveDistance(moveLenght);
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

            playerModel.SetMoveDistance(moveLenght);

            _levelContainer.GameUIView.SetMakeMoveButtonInteractable(false);
        }

        bool IGameModeHandler.TryApplyPathPointEffect(PathPointView pathPointView)
        {
            var containsTask = _levelContainer.PathModel.TaskedPathPointViews.Contains(pathPointView);

            if (containsTask)
            {
                var task = _behaviorMapGenerator.GeneratePathPointBehaviour();

                if (_botsContainer.BotsIdList.Contains(_levelModel.CurrentPlayer.Value.Name))
                {
                    ApplyEffectToBot(task);
                }
                else
                {
                    ApplyEffectToPlayer(task);
                }
            }

            return containsTask;
        }

        private void ApplyEffectToPlayer(IPathPointBehaviour task)
        {
            task.ApplyEffect(_levelModel.CurrentPlayer.Value);
        }

        private void ApplyEffectToBot(IPathPointBehaviour task)
        {
            var randomChance = Random.Range(0, 100);

            if (randomChance > 50)
            {
                _levelModel.CurrentPlayer.Value.SetMoveDistance(task.Reward);
            }
        }
    }
}