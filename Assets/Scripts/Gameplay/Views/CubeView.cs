using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Views
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _value;
        
        private async UniTask PlayTossAnimation(int value)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
        }
    }
}