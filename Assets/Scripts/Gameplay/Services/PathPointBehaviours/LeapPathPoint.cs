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

        public void ApplyEffect(PlayerModel playerModel)
        {
            playerModel.SetMoveDistance(Reward);
        }
    }
}