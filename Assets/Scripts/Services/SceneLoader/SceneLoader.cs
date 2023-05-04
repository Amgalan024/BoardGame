using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Services.SceneLoader
{
    public class SceneLoader
    {
        public async UniTask LoadSceneAsync(AssetReference assetReference)
        {
            await SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            var sceneLoadOperation = Addressables.LoadSceneAsync(assetReference, LoadSceneMode.Additive);

            await sceneLoadOperation;

            SceneManager.SetActiveScene(sceneLoadOperation.Result.Scene);
        }

        public async UniTask LoadSceneWithEnqueuedBuilder(AssetReference assetReference,
            Action<IContainerBuilder> builderAction)
        {
            using (LifetimeScope.Enqueue(builderAction))
            {
                await LoadSceneAsync(assetReference);
            }
        }
    }
}