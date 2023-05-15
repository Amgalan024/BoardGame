using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gameplay.Data;
using UnityEngine;

namespace Views
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private CubeRollData[] _cubeRollData;
        [SerializeField] private float _duration;
        [SerializeField] private Quaternion _quaternion;

        private async UniTask PlayTossAnimation(int value)
        {
            var finalRotation = _cubeRollData.First(c => c.Value == value);
            var otherRotation = _cubeRollData.Where(c => c != finalRotation);

            foreach (var rollData in otherRotation)
            {
                await transform.DORotate(rollData.Quaternion.eulerAngles, _duration);
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.R))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, _quaternion, 0.1f);
            }
        }
    }
}