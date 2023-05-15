using System.Collections.Generic;
using Menu.Views.SubMenuViews;
using UnityEngine;
using Views;

namespace Data
{
    [CreateAssetMenu(fileName = nameof(GameplayVisualData), menuName = "Data/Gameplay/VisualData")]
    public class GameplayVisualData : ScriptableObject
    {
        [SerializeField] private PathData[] _pathData;
        [SerializeField] private List<PlayerViewData> _playerViewData;
        [SerializeField] private GameUIView _gameUIView;
        [SerializeField] private MathTaskView _mathTaskView;
        [SerializeField] private PlayerIconView _playerIconView;
        
        public PathData[] PathData => _pathData;
        public List<PlayerViewData> PlayerViewData => _playerViewData;
        public GameUIView GameUIView => _gameUIView;
        public MathTaskView MathMathTaskView => _mathTaskView;
        public PlayerIconView PlayerIconView => _playerIconView;
    }
}