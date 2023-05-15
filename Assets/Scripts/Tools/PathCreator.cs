using System;
using UnityEngine;
using Views;

namespace Editor.Tools
{
    public class PathCreator : MonoBehaviour
    {
        [SerializeField] private PathPointView _pathPointPrefab;
        [SerializeField] private Transform _parent;
    }
}