using Controllers;
using Data;
using Gameplay.Services;
using Gameplay.Services.Path;
using Models;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameplayVisualData _gameplayVisualData;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterInstance(_gameplayVisualData);

            builder.Register<LevelFactory>(Lifetime.Singleton);
            builder.Register<LevelModel>(Lifetime.Singleton);
            builder.Register<LevelContainer>(Lifetime.Singleton);

            builder.Register<MathTaskMapGenerator>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterEntryPoint<LevelSetupController>();
            builder.RegisterEntryPoint<PlayersController>();
            builder.RegisterEntryPoint<GameplayUIController>();
        }
    }
}