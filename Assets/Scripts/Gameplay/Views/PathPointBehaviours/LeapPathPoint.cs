using Models;
using UnityEngine;

namespace Views.PathPointBehaviours
{
    public class LeapPathPoint : MonoBehaviour, IPathPointBehaviour
    {
        [SerializeField] private int _leapValue;

        public void ApplyEffect(PlayerModel playerModel)
        {
            playerModel.MovePlayer(_leapValue);
        }
    }
}