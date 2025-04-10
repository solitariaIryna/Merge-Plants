using UnityEngine;


namespace MergePlants.State.Entities
{
    public class EntityData
    {
        public int UniqueId { get; set; }
        public string ConfigId { get; set; }
        public EntityType Type { get; set; }
        public Vector2 Position { get; set; }
    }
}
