using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MathTaskView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _taskText;
        [SerializeField] private TMP_InputField _answerInput;
        [SerializeField] private Button _submitAnswerButton;

        [SerializeField] private Transform _rightAnswerPopup;
        [SerializeField] private Transform _wrongAnswerPopup;
        
        public TMP_InputField AnswerInput => _answerInput;
        public Button SubmitAnswerButton => _submitAnswerButton;

        public void SetTaskText(string taskText)
        {
            _taskText.text = taskText;
        }

        public void Clear()
        {
            _answerInput.text = "";
        }

        public async UniTask OpenAsync()
        {
            gameObject.SetActive(true);
        }

        public async UniTask CloseAsync()
        {
            gameObject.SetActive(false);
        }

        public async UniTask PlayCorrectAnswerAnimationAsync()
        {
        }

        public async UniTask PlayWrongAnswerAnimationAsync()
        {
        }
    }
}