using Gameplay.Models.Bot;
using Models;

namespace Views.PathPointBehaviours
{
    public class LeapPathPoint : IPathPointBehaviour
    {
        public LeapPathPoint(int reward)
        {
            Reward = reward;
        }

        public bool IsActive { get; set; }

        public int Reward { get; }

        public void ApplyEffectToPlayer(PlayerModel playerModel)
        {
            playerModel.SetMoveDistance(Reward);
        }

        public void ApplyEffectToBot(BotModel botModel)
        {
            botModel.SetMoveDistance(Reward);
        }
    }
}