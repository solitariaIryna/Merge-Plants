using UnityEngine;

namespace MergePlants.Configs.Enemies
{
    [CreateAssetMenu(fileName = nameof(EnemyAvatarConfig), menuName = "Configs/Gameplay/Enemies/" + nameof(EnemyAvatarConfig))]
    public class EnemyAvatarConfig : ScriptableObject
    {
        [field: SerializeField] public EnemyConfig Config { get; private set; }
        [field: SerializeField] public EnemyVisualConfig VisualConfig { get; private set; }

    }
}
