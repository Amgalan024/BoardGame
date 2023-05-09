using Models;
using UnityEngine;

namespace Views.PathPointBehaviours
{
    public interface IPathPointBehaviour
    {
        void ApplyEffect(PlayerModel playerModel);
    }
}