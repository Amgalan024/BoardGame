using System.Linq;
using Data;
using Models;
using UnityEngine;
using Zenject;

namespace Menu.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private GameplayVisualData _gameplayVisualData;

        public override void InstallBindings()
        {
            var levelSetupModel = new LevelSetupModel
            {
                SelectedPathPrefab = _gameplayVisualData.PathViews.First(),
                GameUIView = _gameplayVisualData.GameUIViews.First(),
                SelectedPlayerPrefabs = _gameplayVisualData.PlayerViews
            };
            
            Container.BindInstance(levelSetupModel).AsSingle();
        }
    }
}