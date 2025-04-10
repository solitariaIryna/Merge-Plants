namespace MergePlants.State.Entities
{
    public abstract class Entity
    {
        public EntityData Data { get; }
        public int UniqueId => Data.UniqueId;
        public string ConfigId => Data.ConfigId;
        public EntityType Type => Data.Type;

        public Entity(EntityData data)
        {
            Data = data;
        }

    }
}
