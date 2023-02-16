using UniRx;

namespace Models
{
    public class PlayerModel
    {
        public ReactiveProperty<int> CurrentProgress { get; } = new ReactiveProperty<int>();
    }
}