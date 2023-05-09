using UnityEngine;

namespace Views
{
    public class PathView : MonoBehaviour
    {
        [SerializeField] private PathPointView[] _pathPoints;

        [SerializeField] private PathPointView _startPathPoint;
        [SerializeField] private PathPointView _finishPathPoint;

        public PathPointView[] PathPoints => _pathPoints;

        public PathPointView StartPathPoint => _startPathPoint;
        public PathPointView FinishPathPoint => _finishPathPoint;
    }
}