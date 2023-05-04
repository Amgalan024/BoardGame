using System.Linq;
using Data;
using Models;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Menu.Installers
{
    public class MenuLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameplayVisualData _gameplayVisualData;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            var levelSetupModel = new LevelSetupModel
            {
                SelectedPathPrefab = _gameplayVisualData.PathViews.First(),
                GameUIView = _gameplayVisualData.GameUIViews.First(),
                SelectedPlayerPrefabs = _gameplayVisualData.PlayerViews
            };

            builder.RegisterInstance(levelSetupModel);
        }
    }
}