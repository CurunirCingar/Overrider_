using UnityEngine;

namespace Logic
{
    public abstract class AlaramableObject : MonoBehaviour
    {
        protected Transform Target { get; set; }

        public virtual void SetTarget(Transform target)
        {
            Target = target;
        }

        public virtual void ResetTarget()
        {
            Target = null;
        }
    }
}