using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Startup
{
    public class StartupLifetimeScope : LifetimeScope
    {
        [SerializeField] private StartupData _startupData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterEntryPoint<StartupController>();
            
            builder.RegisterInstance(_startupData);
        }
    }
}