using MergerPlants.Configs.Levels;
using UnityEngine;

namespace MergerPlants.Configs
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Configs/New " + nameof(GameConfig))]
    public class GameConfig : ScriptableObject
    {
        public LevelsConfigs LevelsConfigs;

    }
}
