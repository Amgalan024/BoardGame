using Controllers;
using Gameplay.Services;
using Models;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<LevelFactory>(Lifetime.Singleton);
            builder.Register<LevelModel>(Lifetime.Singleton);
            builder.Register<LevelContainer>(Lifetime.Singleton);

            builder.Register<LevelSetupController>(Lifetime.Singleton);
            builder.Register<PlayersController>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameplayStartup>();
        }
    }
}