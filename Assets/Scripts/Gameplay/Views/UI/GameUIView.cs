using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField] private Button _makeMoveButton;
        [SerializeField] private LayoutGroup _playerIconsLayoutGroup;

        public Button MakeMoveButton => _makeMoveButton;
        public LayoutGroup PlayerIconsLayoutGroup => _playerIconsLayoutGroup;

        public void SetMakeMoveButtonInteractable(bool value)
        {
            _makeMoveButton.interactable = value;
        }
    }
}