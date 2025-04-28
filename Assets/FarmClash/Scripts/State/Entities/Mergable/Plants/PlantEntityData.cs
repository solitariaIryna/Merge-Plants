using MergePlants.Configs.Plants;

namespace MergePlants.State.Entities.Plants
{
    public class PlantEntityData : MergableEntityData
    {
        public int CellId { get; set; }

        public PlantAvatarConfig Config { get; set; }
    }
}
