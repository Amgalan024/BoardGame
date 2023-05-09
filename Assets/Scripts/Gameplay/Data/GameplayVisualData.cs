using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Data
{
    [CreateAssetMenu(fileName = nameof(GameplayVisualData), menuName = "Data/Gameplay/VisualData")]
    public class GameplayVisualData : ScriptableObject
    {
        [SerializeField] private PathData[] _pathData;
        [SerializeField] private List<PlayerView> _playerViews;
        [SerializeField] private GameUIView _gameUIView;
        [SerializeField] private MathTaskView _mathTaskView;
        
        public PathData[] PathData => _pathData;
        public  List<PlayerView> PlayerViews => _playerViews;
        public GameUIView GameUIView => _gameUIView;
        public MathTaskView MathMathTaskView => _mathTaskView;
    }
}