using System;
using UniRx;

namespace Models
{
    public class PlayerModel
    {
        public event Action<int> OnMoved;
        public int CurrentProgress { get; private set; }

        public void MovePlayer(int steps)
        {
            CurrentProgress += steps;

            OnMoved?.Invoke(CurrentProgress);
        }
    }
}