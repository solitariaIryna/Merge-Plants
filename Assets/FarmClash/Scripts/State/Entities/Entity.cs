using UnityEngine;

namespace MergePlants.State.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        public EntityData Data { get; private set; }
        public int UniqueId => Data.UniqueId;
        public string ConfigId => Data.ConfigId;
        public EntityType Type => Data.Type;

        public Vector3 StartPosition { get; }
        public Vector3 Position { get; set; }

        public void SetData(EntityData data)
        {
            Data = data;
            Position = Data.Position;
        }

    }
}
