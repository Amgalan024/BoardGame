using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Views
{
    public class CubeView : MonoBehaviour
    {
        private async UniTask PlayTossAnimation(int value)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
        }
    }
}