﻿using MergePlants.Configs.Enemies;

namespace MergePlants.State.Entities.Enemies
{
    public class EnemyEntityData : EntityData
    {
        public EnemyType EnemyType { get; set; }

        public EnemyAvatarConfig Config { get; set; }

        public Stat<float> Health = new(0, 0);
    }
}
