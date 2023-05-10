using System.Collections.Generic;

namespace Views.PathPointBehaviours
{
    public interface IBehaviorMapGenerator
    {
        List<PathPointView> GenerateBehavioursMap();
        IPathPointBehaviour GeneratePathPointBehaviour();
    }
}