using System;
using Views;

namespace Models
{
    public class LevelSetupModel
    {
        public event Action LevelSetupFinished;

        public PlayerView[] SelectedPlayerPrefabs { get; set; }
        public PathView SelectedPathPrefab { get; set; }
        public GameUIView GameUIView { get; set; }

        public void InvokeLevelSetupFinish()
        {
            LevelSetupFinished?.Invoke();
        }
    }
}