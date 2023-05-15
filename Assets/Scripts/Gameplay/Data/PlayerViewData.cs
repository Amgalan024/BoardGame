using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerViewData
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Sprite _icon;

        public PlayerView PlayerView => _playerView;
        public Sprite Icon => _icon;
    }
}