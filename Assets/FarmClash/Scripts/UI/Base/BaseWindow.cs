
using UnityEngine;

namespace MergePlants.UI
{
    public abstract class BaseWindow : MonoBehaviour
    {
        public virtual void Deactivate()
        {
            Destroy(gameObject);
        }
    }
}
