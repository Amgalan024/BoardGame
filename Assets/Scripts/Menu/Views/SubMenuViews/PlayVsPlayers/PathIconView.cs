using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views.Icons
{
    public class PathIconView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Toggle _toggle;

        [SerializeField] private Color _activeColor;
        [SerializeField] private Color _inactiveColor;

        public Toggle Toggle => _toggle;

        public void Initialize(Sprite icon)
        {
            _icon.sprite = icon;
        }

        public void SetIconActive(bool value)
        {
            _icon.color = value ? _activeColor : _inactiveColor;
        }
    }
}