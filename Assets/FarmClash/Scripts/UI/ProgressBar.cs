using UnityEngine;
using UnityEngine.UI;

namespace MergePlants.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _current;

        public float FillAmount => _current.fillAmount;

        public void SetValue(float current, float max) =>
            _current.fillAmount = current / max;

        public void SetValue(float current) =>
            _current.fillAmount = current;

    }
}
