using System;
using UnityEngine;

namespace Gameplay.Data
{
    [Serializable]
    public class CubeRollData
    {
        [SerializeField] private int _value;
        [Space]
        [SerializeField] private Quaternion _quaternion;

        public Quaternion Quaternion => _quaternion;
        public int Value => _value;
    }
 }