using Menu.Views.Icons;
using Menu.Views.SubMenuViews;
using UnityEngine;

namespace Menu.Data
{
    [CreateAssetMenu(fileName = nameof(MenuVisualData), menuName = "Data/Menu/MenuVisualData")]
    public class MenuVisualData : ScriptableObject
    {
        [SerializeField] private PathIconView _pathIconView;
        [SerializeField] private PlayerIconView _playerIconView;
        public PathIconView PathIconView => _pathIconView;
        public PlayerIconView PlayerIconView => _playerIconView;
    }
}