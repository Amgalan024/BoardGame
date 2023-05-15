using System;
using Gameplay.Enums;

namespace Models
{
    public class PlayerModel
    {
        public event Action<int, MoveDirection> OnMoveDistanceSet;
        public event Action<int> OnMoved;
        public event Action OnFinished;

        public int CurrentProgress { get; private set; }
        public bool IsActive { get; set; }
        public string Name { get; }

        public int TotalProgress { get; private set; }

        public PlayerModel(string name)
        {
            Name = name;
        }

        public void SetTotalProgress(int totalProgress)
        {
            TotalProgress = totalProgress;
        }

        public void MovePlayer(MoveDirection moveDirection)
        {
            CurrentProgress += (int) moveDirection;

            if (CurrentProgress >= TotalProgress)
            {
                CurrentProgress = TotalProgress;
                IsActive = false;
                OnFinished?.Invoke();
            }

            OnMoved?.Invoke(CurrentProgress);
        }

        public void SetMoveDistance(int steps)
        {
            var moveDirection = steps > 0 ? MoveDirection.Forward : MoveDirection.Backward;

            OnMoveDistanceSet?.Invoke(steps, moveDirection);
        }
    }
}