namespace MergePlants.State.Entities.Cells
{
    public class CellEntityData : EntityData
    {
        public int CellId { get; set; }
        public bool Bought { get; set; }
        public int OccupiedByPlantId { get; set; } = -1;
    }
}
