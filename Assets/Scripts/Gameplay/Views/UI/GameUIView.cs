using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField] private Button _makeMoveButton;

        public Button MakeMoveButton => _makeMoveButton;

        public void SetMakeMoveButtonInteractable(bool value)
        {
            _makeMoveButton.interactable = value;
        }
    }
}