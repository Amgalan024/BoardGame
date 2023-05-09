using System.Collections.Generic;
using System.Linq;
using Models;
using Views;

namespace Gameplay.Services
{
    public class LevelContainer
    {
        public Dictionary<PlayerModel, PlayerView> PlayerViewsByModel { get; } =
            new Dictionary<PlayerModel, PlayerView>();

        public List<PlayerModel> PlayerModels => PlayerViewsByModel.Keys.ToList();
        public List<PlayerView> PlayerViews => PlayerViewsByModel.Values.ToList();

        public PathModel PathModel { get; set; }
        public PathView PathView { get; set; }
        public GameUIView GameUIView { get; set; }
        public MathTaskView MathTaskView { get; set; }
    }
}