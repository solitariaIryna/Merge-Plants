using MergePlants.State.Entities;

namespace MergePlants.Gameplay.View.Plants
{
    public interface IMergable
    {
        EntityType Type { get; }
        int UniqueId { get; }
        int Level { get; }
    }
}
