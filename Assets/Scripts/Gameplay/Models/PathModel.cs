using Services.SceneLoader;

namespace Models
{
    public class PathModel
    {
        public int TotalProgress { get; }

        public PathModel(int totalProgress)
        {
            TotalProgress = totalProgress;
        }
    }
}