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

        private readonly int _maxProgress;

        public PlayerModel(int maxProgress, string name)
        {
            _maxProgress = maxProgress;
            Name = name;
        }

        public void MovePlayer(MoveDirection moveDirection)
        {
            CurrentProgress += (int) moveDirection;

            if (CurrentProgress >= _maxProgress)
            {
                CurrentProgress = _maxProgress;
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