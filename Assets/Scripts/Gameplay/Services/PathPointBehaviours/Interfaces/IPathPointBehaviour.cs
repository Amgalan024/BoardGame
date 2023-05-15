using Gameplay.Models.Bot;
using Models;
using UnityEngine;

namespace Views.PathPointBehaviours
{
    public interface IPathPointBehaviour
    {
        bool IsActive { get; set; }
        public int Reward { get; }
        void ApplyEffectToPlayer(PlayerModel playerModel);
        void ApplyEffectToBot(BotModel botModel);
    }
}