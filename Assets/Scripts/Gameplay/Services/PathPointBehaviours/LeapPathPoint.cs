using Models;

namespace Views.PathPointBehaviours
{
    public class LeapPathPoint : IPathPointBehaviour
    {
        private readonly int _leapValue;

        public LeapPathPoint(int leapValue)
        {
            _leapValue = leapValue;
        }

        public void ApplyEffect(PlayerModel playerModel)
        {
            playerModel.SetMoveDistance(_leapValue);
        }
    }
}