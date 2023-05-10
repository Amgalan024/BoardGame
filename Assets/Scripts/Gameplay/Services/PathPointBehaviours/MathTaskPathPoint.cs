using System;
using Cysharp.Threading.Tasks;
using Models;

namespace Views.PathPointBehaviours
{
    public class MathTaskPathPoint : IPathPointBehaviour
    {
        public bool IsActive { get; set; }
        public int Reward { get; }

        private readonly MathTaskView _mathTaskView;
        private readonly string _taskText;
        private readonly int _answer;

        public MathTaskPathPoint(MathTaskView mathTaskView, string taskText, int answer, int reward)
        {
            _mathTaskView = mathTaskView;
            _taskText = taskText;
            _answer = answer;
            Reward = reward;

            IsActive = true;
        }

        public void ApplyEffect(PlayerModel playerModel)
        {
            IsActive = false;

            _mathTaskView.Clear();
            _mathTaskView.SetTaskText(_taskText);
            _mathTaskView.OpenAsync().Forget();
            _mathTaskView.SubmitAnswerButton.onClick.RemoveAllListeners();
            _mathTaskView.SubmitAnswerButton.onClick.AddListener(() => { SubmitAnswerAsync(playerModel).Forget(); });
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
                await _mathTaskView.PlayWrongAnswerAnimationAsync();
            }

            _mathTaskView.CloseAsync().Forget();
        }
    }
}