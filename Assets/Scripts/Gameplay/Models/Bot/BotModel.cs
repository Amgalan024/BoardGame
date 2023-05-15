using Gameplay.Enums;
using Models;

namespace Gameplay.Models.Bot
{
    public class BotModel : PlayerModel
    {
        public BotsDifficultyTypes BotsDifficultyType { get; }

        public BotModel(string name, BotsDifficultyTypes botsDifficultyType) : base(name)
        {
            BotsDifficultyType = botsDifficultyType;
        }
    }
}