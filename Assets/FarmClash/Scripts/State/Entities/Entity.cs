using UnityEngine;

namespace MergePlants.State.Entities
{
    public abstract class Entity
    {
        public EntityData Data { get; }
        public int UniqueId => Data.UniqueId;
        public string ConfigId => Data.ConfigId;
        public EntityType Type => Data.Type;

        public Vector3 StartPosition { get; }
        public Vector3 Position { get; set; }

        public Entity(EntityData data)
        {
            Data = data;
        }

    }
}
