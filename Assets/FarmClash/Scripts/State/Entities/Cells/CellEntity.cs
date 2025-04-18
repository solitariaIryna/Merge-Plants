using R3;

namespace MergePlants.State.Entities.Cells
{
    public class CellEntity : Entity
    {
        public readonly int CellId;

        public ReactiveProperty<bool> Bought = new(false);
        public ReactiveProperty<int> OccupiedByPlant = new(-1);
        public CellEntity(CellEntityData data) : base(data)
        {
            CellId = data.CellId;
            Bought.Value = data.Bought;
            Position = data.Position;

            Bought.Subscribe(b => data.Bought = b);
            OccupiedByPlant.Subscribe(o => data.OccupiedByPlantId = o);

        }
    }
}
