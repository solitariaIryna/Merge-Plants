using Cysharp.Threading.Tasks;
using MergePlants.Infrastructure.StateMachine;
using MergePlants.Services.SaveLoad;
using R3;

namespace MergePlants.Infrastructure.Gameplay.StatesMachine
{
    public class LoadProgressApplicationState : IState
    {
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressApplicationState(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }
        public async UniTask EnterAsync()
        {
            await LoadProgress();
        }

        public void Exit()
        {
            
        }

        private async UniTask<bool> LoadProgress()
        {
            bool isGameStateLoaded = false;

            _saveLoadService.LoadGameState().Subscribe(_ => isGameStateLoaded = true);
            await UniTask.WaitUntil(() => isGameStateLoaded);

            return isGameStateLoaded;
        }
    }
}
