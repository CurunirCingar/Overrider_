using UnityEngine;

namespace Logic
{
    public sealed class DroneLogicHandler : AlaramableObject
    {
        private LocomotionAgent agent;

        private void Start()
        {
            agent = GetComponent<LocomotionAgent>();
        }

        private void Update()
        {
            if (Target != null)
            {
                agent.SetTarget(Target.position);

                if (Vector3.Distance(transform.position, Target.position) < 1f)
                {
                    var balanceManager = GameRegimeManager.Instance.balanceManager;
                    balanceManager.RecieveDamage(20f);
                }
            }
        }

        public override void ResetTarget()
        {
            
        }
    }
}