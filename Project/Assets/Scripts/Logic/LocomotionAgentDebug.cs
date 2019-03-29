using UnityEngine;

namespace Logic
{
    public class LocomotionAgentDebug : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void Update()
        {
            var agent = GetComponent<LocomotionAgent>();
            agent.SetTarget(target.position);
        }

        [UnityEngine.ContextMenu("Test")]
        private void Test()
        {
            var agent = GetComponent<LocomotionAgent>();
            agent.SetTarget(target.position);
        }
    }
}