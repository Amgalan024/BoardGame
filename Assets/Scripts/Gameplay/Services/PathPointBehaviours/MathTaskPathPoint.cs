using System;
using Cysharp.Threading.Tasks;
using Models;

namespace Views.PathPointBehaviours
{
    public class MathTaskPathPoint : IPathPointBehaviour
    {
        private readonly MathTaskView _mathTaskView;
        private readonly string _taskText;
        private readonly int _answer;
        private readonly int _reward;

        public MathTaskPathPoint(MathTaskView mathTaskView, string taskText, int answer, int reward)
        {
            _mathTaskView = mathTaskView;
            _taskText = taskText;
            _answer = answer;
            _reward = reward;
        }

        public void ApplyEffect(PlayerModel playerModel)
        {
            _mathTaskView.Clear();
            _mathTaskView.SetTaskText(_taskText);
            _mathTaskView.OpenAsync().Forget();

            _mathTaskView.SubmitAnswerButton.onClick.AddListener(() => { SubmitAnswerAsync(playerModel).Forget(); });
        }

        private async UniTaskVoid SubmitAnswerAsync(PlayerModel playerModel)
        {
            if (Convert.ToInt32(_mathTaskView.AnswerInput.text) == _answer)
            {
                playerModel.SetMoveDistance(_reward);
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