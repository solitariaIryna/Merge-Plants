using MergePlants.Gameplay.View.Plants;

namespace MergePlants.State.Entities
{
    public abstract class MergableEntity : Entity, IMergable
    {
        public int Level { get; private set; }

        public void SetData(MergableEntityData data)
        {
            base.SetData(data);

            Level = data.Level;
        }
    }
}
