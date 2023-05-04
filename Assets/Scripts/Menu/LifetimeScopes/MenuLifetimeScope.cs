using Data;
using Menu.Controllers;
using Menu.Data;
using Menu.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Menu.Installers
{
    public class MenuLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameplayVisualData _gameplayVisualData;
        [SerializeField] private MenuData _menuData;
        [SerializeField] private MenuView _menuView;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterInstance(_menuData);
            builder.RegisterInstance(_menuView);
            builder.RegisterInstance(_gameplayVisualData);

            builder.RegisterEntryPoint<MenuController>();
        }
    }
}