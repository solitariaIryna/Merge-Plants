using FarmClash.Configs.Levels;
using UnityEngine;

namespace FarmClash.Configs
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Configs/New " + nameof(GameConfig))]
    public class GameConfig : ScriptableObject
    {
        public LevelsConfigs LevelsConfigs;

    }
}
