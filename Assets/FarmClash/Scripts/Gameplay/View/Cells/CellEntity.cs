using R3;

namespace MergePlants.State.Entities.Cells
{
    public class CellEntity : Entity
    {
        public int CellId { get; private set; }

        public ReactiveProperty<bool> Bought = new(false);
        public ReactiveProperty<int> OccupiedByPlant = new(-1);
        public void SetData(CellEntityData data)
        {
            base.SetData(data);

            CellId = data.CellId;
            Bought.Value = data.Bought;
            Position = data.Position;

            Bought.Subscribe(b => data.Bought = b);
            OccupiedByPlant.Subscribe(o => data.OccupiedByPlantId = o);

            transform.position = data.Position;

        }
    }
}
