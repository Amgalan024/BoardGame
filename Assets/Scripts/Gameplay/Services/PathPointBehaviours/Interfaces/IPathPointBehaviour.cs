using Models;
using UnityEngine;

namespace Views.PathPointBehaviours
{
    public interface IPathPointBehaviour
    {
        bool IsActive { get; set; }
        public int Reward { get; }
        void ApplyEffect(PlayerModel playerModel);
    }
}