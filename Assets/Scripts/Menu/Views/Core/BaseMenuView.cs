using Cysharp.Threading.Tasks;
using Menu.Views.Core.ViewHandlers;
using UnityEngine;

namespace Menu.Views.Core
{
    public class BaseMenuView : MonoBehaviour
    {
        [SerializeField] private BaseMenuViewHandler _menuViewHandler;

        public async UniTask OpenAsync()
        {
            await _menuViewHandler.OpenAsync();
        }

        public async UniTask CloseAsync()
        {
            await _menuViewHandler.CloseAsync();
        }
    }
}