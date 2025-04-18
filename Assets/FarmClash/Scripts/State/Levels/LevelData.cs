using System.Collections.Generic;
using MergePlants.State.Entities;
using MergePlants.State.Entities.Cells;

namespace MergePlants.State.Levels
{
    public class LevelData
    {
        public int Id { get; set; }

        public List<EntityData> Entities = new();
        public List<CellEntityData> Cells = new();

    }

}
