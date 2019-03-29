using UnityEngine;
using UnityEngine.AI;

namespace Logic 
{
    public class LocomotionAgent : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator animator;

        private Vector2 smoothDeltaPosition = Vector2.zero;
        private Vector2 velocity = Vector2.zero;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            agent.updatePosition = false;
        }

        private void Update()
        {
            if (!agent.hasPath)
            {
                animator.SetFloat("InputVertical", 0f, 0.1f, Time.deltaTime);
                return;
            }

            var worldDeltaPosition = agent.nextPosition - transform.position;

            var dx = Vector3.Dot(transform.right, worldDeltaPosition);
            var dy = Vector3.Dot(transform.forward, worldDeltaPosition);
            var deltaPosition = new Vector2(dx, dy);

            var smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
            smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

            if (Time.deltaTime > 1e-5f)
                velocity = smoothDeltaPosition / Time.deltaTime;

            var shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

            animator.SetFloat("InputVertical", agent.velocity.magnitude / agent.speed, 0.1f, Time.deltaTime);

            //if (worldDeltaPosition.magnitude > agent.radius)
            //    transform.position = agent.nextPosition - 0.9f * worldDeltaPosition;
        }

        private void OnAnimatorMove()
        {
            // Update position based on animation movement using navigation surface height
            transform.position = agent.nextPosition;
        }

        public void SetTarget(Vector3 position)
        {
            agent.isStopped = false;
            agent.SetDestination(position);
        }

        public void Stop()
        {
            agent.isStopped = true;
        }
    }
}