using System.Collections.Generic;
using Views;

namespace Models
{
    public class LevelSetupModel
    {
        public List<PlayerView> SelectedPlayerPrefabs { get; set; }
        public PathView SelectedPathPrefab { get; set; }
    }
}