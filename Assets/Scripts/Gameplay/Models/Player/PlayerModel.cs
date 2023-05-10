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
        public bool IsFinished { get; private set; }
        public bool IsActive { get; set; }

        private readonly int _maxProgress;

        public int Index;

        public PlayerModel(int maxProgress, int index)
        {
            _maxProgress = maxProgress;
            Index = index;
        }

        public void MovePlayer(MoveDirection moveDirection)
        {
            CurrentProgress += (int) moveDirection;

            if (CurrentProgress >= _maxProgress)
            {
                CurrentProgress = _maxProgress;
                IsFinished = true;
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