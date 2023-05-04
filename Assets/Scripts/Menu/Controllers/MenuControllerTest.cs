using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.Controllers
{
    public class MenuControllerTest : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex;
        [SerializeField] private Button _startButton;

        private void Start()
        {
            _startButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(_sceneIndex, LoadSceneMode.Additive);
            });
            
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
        }
    }
}