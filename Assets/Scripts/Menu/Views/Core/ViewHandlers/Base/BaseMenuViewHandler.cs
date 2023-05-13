using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Menu.Views.Core.ViewHandlers
{
    public abstract class BaseMenuViewHandler : MonoBehaviour
    {
        public abstract UniTask OpenAsync();
        public abstract UniTask CloseAsync();
    }
}