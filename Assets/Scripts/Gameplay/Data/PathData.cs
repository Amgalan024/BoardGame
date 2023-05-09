using System;
using UnityEngine;
using Views;

namespace Data
{
    [Serializable]
    public class PathData
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private PathView _prefab;

        public Sprite Icon => _icon;
        public PathView Prefab => _prefab;
    }
}