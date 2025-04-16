
using UnityEngine;

namespace MergePlants.Gameplay.Interactable
{
    public interface IInteractable
    {
        Vector3 Position { get; }
        bool CanInteract { get; }


        void SelectionStarted(Vector2 position);
        void SelectionHolded(Vector2 position);
        void SelectionEnded(Vector3 position);

    }
}
