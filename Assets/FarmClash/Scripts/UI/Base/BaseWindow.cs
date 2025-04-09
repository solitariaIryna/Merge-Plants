
using UnityEngine;

namespace FarmClash.UI
{
    public abstract class BaseWindow : MonoBehaviour
    {
        public virtual void Deactivate()
        {
            Destroy(gameObject);
        }
    }
}
