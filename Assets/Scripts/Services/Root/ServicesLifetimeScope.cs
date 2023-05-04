using VContainer;
using VContainer.Unity;

namespace Services.Root
{
    public class ServicesLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<SceneLoader.SceneLoader>(Lifetime.Singleton);
        }
    }
}