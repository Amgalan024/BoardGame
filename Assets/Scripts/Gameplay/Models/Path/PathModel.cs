using System.Collections.Generic;
using Views;
using Views.PathPointBehaviours;

namespace Models
{
    public class PathModel
    {
        public int TotalProgress { get; }

        public Dictionary<PathPointView, IPathPointBehaviour> PathPointBehaviours { get; } =
            new Dictionary<PathPointView, IPathPointBehaviour>();

        public PathModel(int totalProgress)
        {
            TotalProgress = totalProgress;
        }
    }
}