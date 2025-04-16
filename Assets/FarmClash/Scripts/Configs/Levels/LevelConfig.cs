using UnityEngine;

namespace MergerPlants.Configs.Levels
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "Configs/Levels/" + nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        public int LevelId;

    }

}
