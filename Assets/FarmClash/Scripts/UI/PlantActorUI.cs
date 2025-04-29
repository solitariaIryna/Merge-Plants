using UnityEngine;
using TMPro;
using MergePlants.Gameplay.Plants;

namespace MergePlants.UI
{
    public class PlantActorUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private PlantEntity _plant;

        [SerializeField] private string _levelTextFormat = "Level {0}";

        private void Start()
        {
            _levelText.text = string.Format(_levelTextFormat, _plant.Level);
        }

    }
}
