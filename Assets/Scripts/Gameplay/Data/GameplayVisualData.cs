using UnityEngine;
using Views;

namespace Data
{
    [CreateAssetMenu(fileName = nameof(GameplayVisualData), menuName = "Data/Gameplay/VisualData")]
    public class GameplayVisualData : ScriptableObject
    {
        [SerializeField] private PathView[] _pathViews;
        [SerializeField] private PlayerView[] _playerViews;
        [SerializeField] private GameUIView[] _gameUIViews;

        public PathView[] PathViews => _pathViews;
        public PlayerView[] PlayerViews => _playerViews;
        public GameUIView[] GameUIViews => _gameUIViews;
    }
}