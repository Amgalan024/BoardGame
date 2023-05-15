using System;
using Cysharp.Threading.Tasks;
using Gameplay.Models.Bot;
using Models;

namespace Views.PathPointBehaviours
{
    public class MathTaskPathPoint : IPathPointBehaviour
    {
        public bool IsActive { get; set; }
        public int Reward { get; }

        private LevelModel _levelModel;
        private readonly MathTaskView _mathTaskView;
        private readonly string _taskText;
        private readonly int _answer;

        public MathTaskPathPoint(MathTaskView mathTaskView, LevelModel levelModel, string taskText, int answer,
            int reward)
        {
            _mathTaskView = mathTaskView;
            _levelModel = levelModel;
            _taskText = taskText;
            _answer = answer;
            Reward = reward;

            IsActive = true;
        }

        public void ApplyEffectToPlayer(PlayerModel playerModel)
        {
            IsActive = false;

            _mathTaskView.Clear();
            _mathTaskView.SetTaskText(_taskText);
            _mathTaskView.OpenAsync().Forget();
            _mathTaskView.SubmitAnswerButton.onClick.RemoveAllListeners();
            _mathTaskView.SubmitAnswerButton.onClick.AddListener(() => { SubmitAnswerAsync(playerModel).Forget(); });
        }

        public void ApplyEffectToBot(BotModel botModel)
        {
            botModel.SetMoveDistance(Reward);
        }

        private async UniTaskVoid SubmitAnswerAsync(PlayerModel playerModel)
        {
            if (Convert.ToInt32(_mathTaskView.AnswerInput.text) == _answer)
            {
                playerModel.SetMoveDistance(Reward);
                await _mathTaskView.PlayCorrectAnswerAnimationAsync();
            }
            else
            {
                _levelModel.ChangeTurn();
                await _mathTaskView.PlayWrongAnswerAnimationAsync();
            }

            _mathTaskView.CloseAsync().Forget();
        }
    }
}