using System;
using UnityEngine;
using UnityEngine.Events;

namespace CreatingWithCharlotte.Helpers
{
    public class ColliderTrigger : MonoBehaviour
    {
        public CollisionType Type;
        public bool ShouldUseCustomCollider = false;
        public Collider CustomCollider;
        public UnityEvent FunctionToTrigger;

        public enum CollisionType
        {
            OnCollisionEnter,
            OnCollisionExit,
            OnCollisionStay,
            OnTriggerEnter,
            OnTriggerExit,
            OnTriggerStay,
            OnMouseUp
        }

        private void OnEnable()
        {
            if (ShouldUseCustomCollider && !CustomCollider)
            {
                Debug.LogError(gameObject.name + ": [TriggerOnCollision] CustomCollider empty but ShouldUseCustomCollider is true");
            }
            if (FunctionToTrigger?.GetPersistentEventCount() == 0)
            {
                Debug.LogWarning(gameObject.name + ": [TriggerOnCollision] No events added in case of collision.");
            }
        }

        //This function will only work if this gameobject has a Collider component with Is Trigger false
        //The other gameobject needs to have a RigidBody and a Collider
        private void OnCollisionEnter(Collision collision)
        {
            if (Type == CollisionType.OnCollisionEnter)
            {
                if (ShouldUseCustomCollider && !collision.Equals(CustomCollider))
                    return;

                FunctionToTrigger?.Invoke();
            }
        }

        //This function will only work if this gameobject has a Collider component with Is Trigger false
        //The other gameobject needs to have a RigidBody and a Collider
        private void OnCollisionExit(Collision collision)
        {
            if (Type == CollisionType.OnCollisionExit)
            {
                if (ShouldUseCustomCollider && !collision.Equals(CustomCollider))
                    return;

                FunctionToTrigger?.Invoke();
            }
        }

        //This function will only work if this gameobject has a Collider component with Is Trigger false
        //The other gameobject needs to have a RigidBody and a Collider
        private void OnCollisionStay(Collision collision)
        {
            if (Type == CollisionType.OnCollisionStay)
            {
                if (ShouldUseCustomCollider && !collision.Equals(CustomCollider))
                    return;

                FunctionToTrigger?.Invoke();
            }
        }

        //This function will only work if this gameobject has a Collider component with Is Trigger true
        //The other gameobject needs to have a RigidBody and a Collider
        private void OnTriggerEnter(Collider collision)
        {
            if (Type == CollisionType.OnTriggerEnter)
            {
                if (ShouldUseCustomCollider && !collision.Equals(CustomCollider))
                    return;

                FunctionToTrigger?.Invoke();
            }
        }

        //This function will only work if this gameobject has a Collider component with Is Trigger true
        //The other gameobject needs to have a RigidBody and a Collider
        private void OnTriggerExit(Collider collision)
        {
            if (Type == CollisionType.OnTriggerExit)
            {
                if (ShouldUseCustomCollider && !collision.Equals(CustomCollider))
                    return;

                FunctionToTrigger?.Invoke();
            }
        }

        //This function will only work if this gameobject has a Collider component with Is Trigger true
        //The other gameobject needs to have a RigidBody and a Collider
        private void OnTriggerStay(Collider collision)
        {
            if (Type == CollisionType.OnTriggerStay)
            {
                if (ShouldUseCustomCollider && !collision.Equals(CustomCollider))
                    return;

                FunctionToTrigger?.Invoke();
            }
        }

        //This function will only work if the gameobject has a Collider component
        private void OnMouseUpAsButton()
        {
            Debug.Log("The user clicked on " + gameObject.name);
            if (Type == CollisionType.OnMouseUp)
            {
                FunctionToTrigger?.Invoke();
            }
        }
    } 
}
