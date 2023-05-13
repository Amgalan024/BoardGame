using System.Collections.Generic;
using Views;

namespace Models
{
    public class LevelSetupModel
    {
        public Dictionary<string, PlayerView> SelectedPlayerPrefabsByName { get; } =
            new Dictionary<string, PlayerView>();

        public PathView SelectedPathPrefab { get; set; }
    }
}