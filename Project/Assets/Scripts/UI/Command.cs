using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public abstract class Command : MonoBehaviour
    {
        public abstract string Caption { get; }
        public abstract int Cost { get; }
        public abstract int ActiveTime { get; }

        public Action OnCommandActivated;
        public Action OnCommandDisabled;

        private void Awake()
        {
        }

        public virtual void Activate()
        {
            if (OnCommandActivated != null)
            {
                OnCommandActivated();
            }
        }

        public virtual void Disable()
        {
            if (OnCommandDisabled != null)
            {
                OnCommandDisabled();
            }
        }
    }
}