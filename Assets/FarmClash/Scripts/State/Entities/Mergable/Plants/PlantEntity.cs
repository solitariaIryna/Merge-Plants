using R3;

namespace MergePlants.State.Entities.Plants
{
    public class PlantEntity : MergableEntity
    {
        public ReactiveProperty<int> CellId = new();
        public new PlantEntityData Data => (PlantEntityData)Data;
        public PlantEntity(PlantEntityData data) : base(data)
        {
            CellId.Value = data.CellId;

            CellId.Subscribe(c => data.CellId = c);
        }
    }
}
