using System.Linq;
using Controllers;
using Data;
using Gameplay.Services;
using Models;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LevelSetupInstaller : MonoInstaller
    {
        [SerializeField] private GameplayVisualData _gameplayVisualData;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelFactory>().AsSingle();
            Container.Bind<LevelContainer>().AsSingle().MoveIntoAllSubContainers();
            Container.Bind<LevelModel>().AsSingle().MoveIntoAllSubContainers();
            
            //todo: потом будет заполняться и передаваться с меню
            var levelSetupModel = new LevelSetupModel();
            
            levelSetupModel.SelectedPathPrefab = _gameplayVisualData.PathViews.First();
            levelSetupModel.GameUIView = _gameplayVisualData.GameUIViews.First();
            levelSetupModel.SelectedPlayerPrefabs = _gameplayVisualData.PlayerViews;
            
            Container.BindInstance(levelSetupModel).AsSingle();

            Container.BindInterfacesTo<LevelSetupController>().AsSingle();
        }
    }
}