using System.Collections.Generic;
using Views;
using Views.PathPointBehaviours;

namespace Models
{
    public class PathModel
    {
        public int TotalProgress { get; }

        public List<PathPointView> TaskedPathPointViews { get; } =
            new List<PathPointView>();

        public PathModel(int totalProgress)
        {
            TotalProgress = totalProgress;
        }
    }
}