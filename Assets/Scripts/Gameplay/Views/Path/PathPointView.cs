using TMPro;
using UnityEngine;

namespace Views
{
    public class PathPointView : MonoBehaviour
    {
        [SerializeField] private Transform _rewardSign;

        public void PlayActivateAnimation()
        {
        }

        public void PlayDeactivateAnimation()
        {
        }

        public void SetTaskSign()
        {
            _rewardSign.gameObject.SetActive(true);
        }
    }
}