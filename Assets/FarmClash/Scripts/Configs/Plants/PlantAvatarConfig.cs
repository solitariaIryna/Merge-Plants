using UnityEngine;

namespace MergePlants.Configs.Plants
{
    [CreateAssetMenu(fileName = nameof(PlantAvatarConfig), menuName = "Configs/Gameplay/Plants/" + nameof(PlantAvatarConfig))]
    public class PlantAvatarConfig : ScriptableObject
    {
        [field: SerializeField] public PlantConfig Config { get; private set; }
        [field: SerializeField] public PlantVisualConfig VisualConfig { get; private set; }
    }

}
