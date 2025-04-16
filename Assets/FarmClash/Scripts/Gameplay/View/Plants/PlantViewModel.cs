using MergePlants.Gameplay.Services;
using MergePlants.State.Entities.Plants;
using MergerPlants.Gameplay.View.Draggable;
using UnityEngine;

namespace MergerPlants.Gameplay.View.Plants
{
    public class PlantViewModel : ReturningDraggableViewModel
    {
        private readonly PlantEntity _plantEntity;
        private readonly PlantsService _plantsService;
      
        public PlantViewModel(PlantEntity plantEntity, PlantsService plantsService)
        {
            _plantEntity = plantEntity;
            _plantsService = plantsService;

            Position.Value = plantEntity.Position;
        }

        public void UpdatePosition(Vector3 newPosition)
        {
            Position.Value = newPosition;
            _plantEntity.Position = newPosition;
        }
    }
    public class PlantBinder : ReturningDraggableBinder
    {
        private PlantViewModel _plantViewModel;
        public void Bind(PlantViewModel viewModel)
        {
            _plantViewModel = viewModel;

            base.Bind(viewModel);
        }

        public override void OnSelectionStarted(Vector3 position)
        {
            base.OnSelectionStarted(position);
        }

        public override void OnSelectionHolded(Vector2 position)
        {
            base.OnSelectionHolded(position);
        }

        public override void OnSelectionEnded(Vector3 position)
        {
            base.OnSelectionEnded(position);
        }

    }
}
