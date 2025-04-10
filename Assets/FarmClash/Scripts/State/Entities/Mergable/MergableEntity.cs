using R3;

namespace MergePlants.State.Entities
{
    public abstract class MergableEntity : Entity
    {
        public readonly ReactiveProperty<int> Level;

        public MergableEntity(MergableEntityData data) : base(data)
        {
            Level = new ReactiveProperty<int>(data.Level);
            Level.Subscribe(newValue => data.Level = newValue);
        }
    }
}
