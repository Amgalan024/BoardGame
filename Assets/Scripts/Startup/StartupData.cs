using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Startup
{
    [CreateAssetMenu(fileName = nameof(StartupData), menuName = "Data/Startup/StartupData")]
    public class StartupData : ScriptableObject
    {
        [SerializeField] private AssetReference _menuScene;
        [SerializeField] private AssetReference _servicesScene;

        public AssetReference MenuScene => _menuScene;
        public AssetReference ServicesScene => _servicesScene;
    }
}