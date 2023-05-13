using Cysharp.Threading.Tasks;

namespace Menu.Views.Core.ViewHandlers
{
    public class TempMenuViewHandler : BaseMenuViewHandler
    {
        public override async UniTask OpenAsync()
        {
            gameObject.SetActive(true);
        }

        public override async UniTask CloseAsync()
        {
            gameObject.SetActive(false);
        }
    }
}