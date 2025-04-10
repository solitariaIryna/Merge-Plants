using R3;

namespace MergePlants.State.Root
{
    public class GameSettingsStateProxy
    {
        public ReactiveProperty<int> MusicVolume { get; }
        public ReactiveProperty<int> SFXVolume { get; }
        public ReactiveProperty<bool> Vibration { get; }

        public GameSettingsStateProxy(GameSettingsState gameSettingsState)
        {
            MusicVolume = new ReactiveProperty<int>(gameSettingsState.MusicVolume);
            SFXVolume = new ReactiveProperty<int>(gameSettingsState.SFXVolume);
            Vibration = new ReactiveProperty<bool>(gameSettingsState.Vibration);

            MusicVolume.Skip(1).Subscribe(value => gameSettingsState.MusicVolume = value);
            SFXVolume.Skip(1).Subscribe(value => gameSettingsState.SFXVolume = value);
            Vibration.Skip(1).Subscribe(value => gameSettingsState.Vibration = value);
        }
    }
}
