using MergePlants.Configs.Plants;
using MergePlants.Gameplay.Services;
using MergePlants.State.Entities;
using MergePlants.State.Entities.Plants;
using R3;
using UnityEngine;

namespace MergePlants.Gameplay.View.Plants
{
    public class PlantViewModel
    {
        private readonly PlantEntity _plantEntity;
        private readonly PlantsService _plantsService;

        public readonly int EntityId;
        public readonly PlantAvatarConfig Config;
        public ReactiveProperty<int> Level { get; } = new();

        public readonly EntityType Type;
        public ReactiveProperty<Vector3> Position { get; } = new();
      
        public PlantViewModel(PlantEntity plantEntity, PlantAvatarConfig config, PlantsService plantsService)
        {
            _plantEntity = plantEntity;
            _plantsService = plantsService;
            Config = config;
            Type = plantEntity.Type;
            EntityId = plantEntity.UniqueId;
            Level.Value = plantEntity.Level.Value;
            Position.Value = plantEntity.Position;
        }

        public void UpdatePosition(Vector3 newPosition)
        {
            Position.Value = newPosition;
            _plantEntity.Position = newPosition;
        }

        public bool TryRequestMerge(IMergable other)
        {
            if (other.Type == Type && other.Level == Level.Value)
            {
                _plantsService.TryMergePlants(EntityId, other.EntityId);
                return true;
            }
            return false;
        }
    }
}
