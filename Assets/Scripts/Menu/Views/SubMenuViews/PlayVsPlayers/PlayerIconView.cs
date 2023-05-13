using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Views.SubMenuViews
{
    public class PlayerIconView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Image _icon;

        public void SetName(string playerName)
        {
            _nameText.text = playerName;
        }

        public void SetIcon(Sprite iconSprite)
        {
            _icon.sprite = iconSprite;
        }
    }
}