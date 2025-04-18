using UnityEngine;

namespace MergePlants.Configs.Levels
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "Configs/Levels/" + nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        public int LevelId;
        public Vector2 CellCount;
        public Vector3 StartPosition = new Vector3(-0.5f, 0, 0);
        public Vector3 CellOffset = new Vector3(0.5f, 0.5f, 0);

    }

}
