using System.Collections.Generic;
using Data;
using Views;

namespace Models
{
    public class LevelSetupModel
    {
        public Dictionary<PlayerModel, PlayerViewData> PlayerViewDataByModels { get; } =
            new Dictionary<PlayerModel, PlayerViewData>();

        public PathView SelectedPathPrefab { get; set; }
    }
}