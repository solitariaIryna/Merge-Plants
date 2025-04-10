using System;

namespace MergePlants.State.Root
{
    [Serializable]
    public class GameSettingsState
    {
        public int MusicVolume;
        public int SFXVolume;
        public bool Vibration;
    }
}
