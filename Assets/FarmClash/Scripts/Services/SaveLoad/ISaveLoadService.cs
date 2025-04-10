using MergePlants.State.Root;
using R3;

namespace MergePlants.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        GameStateProxy GameState { get; }
        GameSettingsStateProxy SettingsState { get; }

        Observable<GameStateProxy> LoadGameState();
        Observable<GameSettingsStateProxy> LoadSettingsState();
        Observable<bool> ResetGameState();
        Observable<GameSettingsStateProxy> ResetSettingsState();
        Observable<bool> SaveGameState();
        Observable<bool> SaveSettingsState();
    }
}
