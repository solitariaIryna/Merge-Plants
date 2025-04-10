using MergePlants.State.GameResources;
using MergePlants.State.Levels;
using System.Collections.Generic;

namespace MergePlants.State.Root
{
    public class GameState
    {
        public int GlobalEntityId { get; set; }
        public int CurrentLevelId { get; set; }

        public List<LevelData> Levels { get; set; } 
        public List<ResourceData> Resources { get; set; }

        public int CreateEntityId() =>
            GlobalEntityId++;

    }
}
