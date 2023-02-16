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
            Container.Bind<LevelFactory>().ToSelf().AsSingle();
            Container.Bind<LevelModel>().ToSelf().AsSingle();
            Container.Bind<LevelContainer>().ToSelf().AsSingle();
            
            //todo: потом будет заполняться и передаваться с меню
            var levelSetupModel = new LevelSetupModel
            {
                SelectedPathPrefab = _gameplayVisualData.PathViews.First(),
                GameUIView = _gameplayVisualData.GameUIViews.First(),
                SelectedPlayerPrefabs = _gameplayVisualData.PlayerViews
            };

            Container.BindInstance(levelSetupModel).AsSingle();

            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIController>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayersController>().AsSingle();
            
            Container.BindInterfacesTo<ControllersEntryPoint>().AsSingle();

        }
    }
}