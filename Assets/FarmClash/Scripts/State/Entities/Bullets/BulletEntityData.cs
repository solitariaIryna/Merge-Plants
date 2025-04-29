using UnityEngine;

namespace MergePlants.State.Entities.Bullets
{
    public class BulletEntityData : EntityData
    {
        public Transform Target { get; set; }

        public float Damage { get; set; }
        public float Speed { get; set; }

    }
}
