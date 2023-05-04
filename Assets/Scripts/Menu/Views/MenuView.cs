using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        public Button StartButton => _startButton;
    }
}