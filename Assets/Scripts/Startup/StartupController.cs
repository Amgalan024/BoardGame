using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Startup
{
    public class StartupController : IInitializable
    {
        private readonly StartupData _startupData;

        public StartupController(StartupData startupData)
        {
            _startupData = startupData;
        }

        void IInitializable.Initialize()
        {
            StartupAsync().Forget();
        }

        private async UniTaskVoid StartupAsync()
        {
            var startupScene = SceneManager.GetActiveScene();

            var servicesLoadOp = Addressables.LoadSceneAsync(_startupData.ServicesScene, LoadSceneMode.Additive);
            var menuLoadOp = Addressables.LoadSceneAsync(_startupData.MenuScene, LoadSceneMode.Additive);

            await UniTask.WhenAll(servicesLoadOp.ToUniTask(), menuLoadOp.ToUniTask());

            await SceneManager.UnloadSceneAsync(startupScene);

            SceneManager.SetActiveScene(menuLoadOp.Result.Scene);
        }
    }
}