using Menu.Views.Icons;
using UnityEngine;

namespace Menu.Data
{
    [CreateAssetMenu(fileName = nameof(MenuVisualData), menuName = "Data/Menu/MenuVisualData")]
    public class MenuVisualData :  ScriptableObject
    {
        [SerializeField] private PathIconView _pathIconView;

        public PathIconView PathIconView => _pathIconView;
    }
}