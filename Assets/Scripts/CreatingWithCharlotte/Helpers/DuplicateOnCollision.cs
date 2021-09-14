using System.Collections.Generic;
using UnityEngine;

namespace CreatingWithCharlotte.Helpers
{
    public class DuplicateOnCollision : MonoBehaviour
    {
        public List<Transform> TriggerObjects;
        public int MaxAmount = 20;
        public int Amount = 2;
        public float Scale = 0.5f;
        private float _minimumVelocityNeeded = 0.6f;
        private List<GameObject> _spawnedGameObjects = new List<GameObject>();

        private void OnCollisionExit(Collision collision)
        {
            Duplicate(collision);
        }

        public void Duplicate(Collision collision)
        {
            if (TriggerObjects == null || !TriggerObjects.Contains(collision.transform))
                return;
            //print("velocity: " + collision?.relativeVelocity.magnitude);
            if (collision?.relativeVelocity.magnitude < _minimumVelocityNeeded)
                return;
            CreateNewObjects();
            DestroySelf();
        }

        private void CreateNewObjects()
        {
            CheckAndDestroyObjects();
            for (int i = 0; i < Amount; i++)
            {
                var g = GameObject.Instantiate(gameObject, transform.parent);
                g.transform.localScale = new Vector3(Scale, Scale, Scale);
                _spawnedGameObjects.Add(g);
            }
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }

        private void CheckAndDestroyObjects()
        {
            if (_spawnedGameObjects.Count > MaxAmount)
            {
                var length = _spawnedGameObjects.Count - MaxAmount;
                for (int i = 0; i < length; i++)
                {
                    Destroy(_spawnedGameObjects[length - 1 - i]);
                    _spawnedGameObjects.RemoveAt(length - 1 - i);
                }
                //print("Now only " + _spawnedGameObjects.Count + " spheres remain. " + transform.childCount);
            }
        }
    } 
}
