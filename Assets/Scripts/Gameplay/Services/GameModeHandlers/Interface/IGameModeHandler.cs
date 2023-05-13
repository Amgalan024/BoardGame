using Views;

namespace Gameplay.Services.TurnControllerStrategies.Interface
{
    public interface IGameModeHandler
    {
        void OnTurnChanged();
        void OnMoveButtonClicked();
        bool TryApplyPathPointEffect(PathPointView pathPointView);
    }
}