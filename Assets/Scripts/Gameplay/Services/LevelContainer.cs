using System.Collections.Generic;
using Models;
using Views;

namespace Gameplay.Services
{
    public class LevelContainer
    {
        public Dictionary<PlayerModel, PlayerView> PlayerViewsByModel { get; } =
            new Dictionary<PlayerModel, PlayerView>();

        public LinkedList<PlayerModel> LinkedPlayerModels = new LinkedList<PlayerModel>();

        public PathModel PathModel { get; set; }
        public PathView PathView { get; set; }

        public GameUIView GameUIView { get; set; }
    }
}