using MergePlants.State.GameResources;
using MergePlants.State.Levels;
using MergePlants.State.Root;
using Newtonsoft.Json;
using R3;
using System.Collections.Generic;
using UnityEngine;

namespace MergePlants.Services.SaveLoad
{
    public class PlayerPrefsSaveLoadService : ISaveLoadService
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
        private const string GAME_SETTINGS_STATE_KEY = nameof(GAME_SETTINGS_STATE_KEY);

        public GameStateProxy GameState { get; private set; }
        public GameSettingsStateProxy SettingsState { get; private set; }

        private GameState _gameState;
        private GameSettingsState _gameSettingsState;
        public Observable<GameStateProxy> LoadGameState()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            };

            if (!PlayerPrefs.HasKey(GAME_STATE_KEY))
            {
                GameState = CreateGameStateFromSettings();
                Debug.Log("Game State created from settings: " + JsonConvert.SerializeObject(_gameState, Formatting.Indented));

                SaveGameState();    
            }
            else
            {
                var json = PlayerPrefs.GetString(GAME_STATE_KEY);
                _gameState = JsonConvert.DeserializeObject<GameState>(json);
                GameState = new GameStateProxy(_gameState);

                Debug.Log("Game State loaded: " + json);
            }

            return Observable.Return(GameState);
        }

        public Observable<GameSettingsStateProxy> LoadSettingsState()
        {
            if (!PlayerPrefs.HasKey(GAME_SETTINGS_STATE_KEY))
            {
                SettingsState = CreateGameSettingsStateFromSettings();

                SaveSettingsState();    
            }
            else
            {
                var json = PlayerPrefs.GetString(GAME_SETTINGS_STATE_KEY);
                _gameSettingsState = JsonConvert.DeserializeObject<GameSettingsState>(json);
                SettingsState = new GameSettingsStateProxy(_gameSettingsState);
            }

            return Observable.Return(SettingsState);
        }
        public Observable<bool> SaveGameState()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(_gameState, settings);
            PlayerPrefs.SetString(GAME_STATE_KEY, json);

            return Observable.Return(true);
        }

        public Observable<bool> SaveSettingsState()
        {
            var json = JsonConvert.SerializeObject(_gameSettingsState, Formatting.Indented);
            PlayerPrefs.SetString(GAME_SETTINGS_STATE_KEY, json);

            return Observable.Return(true);
        }

        public Observable<bool> ResetGameState()
        {
            GameState = CreateGameStateFromSettings();
            SaveGameState();

            return Observable.Return(true);
        }

        public Observable<GameSettingsStateProxy> ResetSettingsState()
        {
            SettingsState = CreateGameSettingsStateFromSettings();
            SaveSettingsState();

            return Observable.Return(SettingsState);
        }
        private GameStateProxy CreateGameStateFromSettings()
        {
            _gameState = new GameState
            {
                Levels = new List<LevelData>(),
                Resources = new List<ResourceData>()
                {
                    new() { Amount = 0, ResourceType = ResourceType.SoftCurrency },
                    new() { Amount = 0, ResourceType = ResourceType.HardCurrency },
                }
            };

            return new GameStateProxy(_gameState);
        }

        private GameSettingsStateProxy CreateGameSettingsStateFromSettings()
        {
            _gameSettingsState = new GameSettingsState()
            {
                MusicVolume = 8,
                SFXVolume = 8
            };

            return new GameSettingsStateProxy(_gameSettingsState);
        }
    }
}
