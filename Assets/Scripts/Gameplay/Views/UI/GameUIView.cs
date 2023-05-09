using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField] private Button _makeMoveButton;

        public Button MakeMoveButton => _makeMoveButton;
    }
}