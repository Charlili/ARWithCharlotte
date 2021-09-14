using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace CreatingWithCharlotte.Helpers
{
    public class SpeedTrigger : MonoBehaviour
    {
        public UnityEvent FunctionToTrigger;
        private Rigidbody _rigidbody;
        private NavMeshAgent _agent;
        public bool IsHigherThan = true;
        public float Range = 5f;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (_rigidbody == null)
                return;

            if (_agent != null && _agent.isActiveAndEnabled)
            {

                if (IsHigherThan && _agent.velocity.magnitude > Range)
                {
                    FunctionToTrigger?.Invoke();
                }
                else if (!IsHigherThan && _agent.velocity.magnitude < Range)
                {
                    FunctionToTrigger?.Invoke();
                }
            }
            else
            {
                if (IsHigherThan && _rigidbody.velocity.magnitude > Range)
                {
                    FunctionToTrigger?.Invoke();
                }
                else if (!IsHigherThan && _rigidbody.velocity.magnitude < Range)
                {
                    FunctionToTrigger?.Invoke();
                }
            }
        }
    }
}