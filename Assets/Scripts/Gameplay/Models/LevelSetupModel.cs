using Views;

namespace Models
{
    public class LevelSetupModel
    {
        public PlayerView[] SelectedPlayerPrefabs { get; set; }
        public PathView SelectedPathPrefab { get; set; }
        public GameUIView GameUIView { get; set; }
    }
}