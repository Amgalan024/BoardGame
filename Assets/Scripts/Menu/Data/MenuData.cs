using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Menu.Data
{
    [CreateAssetMenu(fileName = nameof(MenuData), menuName = "Data/Menu/MenuData")]
    public class MenuData : ScriptableObject
    {
        [SerializeField] private AssetReference _gameplayScene;
        [SerializeField] private BotDifficultyData[] _botDifficultyConfigs;
        public BotDifficultyData[] BotDifficultyConfigs => _botDifficultyConfigs;
        public AssetReference GameplayScene => _gameplayScene;
    }
}