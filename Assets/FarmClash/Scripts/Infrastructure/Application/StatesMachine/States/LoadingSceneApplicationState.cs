using Cysharp.Threading.Tasks;
using MergePlants.Infrastructure.StateMachine;

namespace MergePlants.Infrastructure.App.StatesMachine
{
    public class LoadingSceneApplicationState : IPayloadState<string>
    {
        private SceneLoader _sceneLoader;

        public LoadingSceneApplicationState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async UniTask EnterAsync(string sceneName)
        {
           await LoadScene(sceneName);
        }

        public void Exit()
        {

        }

        private async UniTask LoadScene(string sceneName)
        {
            await _sceneLoader.Load(sceneName);
        }
    }

}


