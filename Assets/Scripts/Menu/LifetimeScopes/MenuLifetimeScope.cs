using Data;
using Menu.Controllers;
using Menu.Data;
using Menu.Views;
using Menu.Views.SubMenuViews;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Menu.Installers
{
    public class MenuLifetimeScope : LifetimeScope
    {
        [Header("Data"), SerializeField] private GameplayVisualData _gameplayVisualData;
        [SerializeField] private MenuData _menuData;
        [SerializeField] private MenuVisualData _menuVisualData;

        [Header("Views"), SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private PlayVsPlayersView _playVsPlayersView;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterInstance(_menuData);
            builder.RegisterInstance(_menuVisualData);
            builder.RegisterInstance(_gameplayVisualData);

            builder.RegisterInstance(_mainMenuView);
            builder.RegisterInstance(_playVsPlayersView);

            builder.RegisterEntryPoint<MainMenuController>();
            builder.RegisterEntryPoint<PlayVsPlayersController>();
        }
    }
}