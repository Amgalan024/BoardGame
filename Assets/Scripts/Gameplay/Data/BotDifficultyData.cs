using System;
using Gameplay.Enums;
using UnityEngine;

namespace Menu.Data
{
    [Serializable]
    public class BotDifficultyData
    {
        [SerializeField] private BotsDifficultyTypes _botsDifficultyType;
        [SerializeField] private string _dropDownText;

        public BotsDifficultyTypes BotsDifficultyType => _botsDifficultyType;
        public string DropDownText => _dropDownText;
    }
}