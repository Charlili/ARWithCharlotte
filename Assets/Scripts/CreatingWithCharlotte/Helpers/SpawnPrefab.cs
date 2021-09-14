using System.Collections.Generic;
using UnityEngine;

namespace CreatingWithCharlotte.Helpers
{
    public class SpawnPrefab : MonoBehaviour
    {
        public bool SpawnOnStart = false;
        public GameObject Prefab;
        private List<GameObject> _createdObjects;

        void Start()
        {
            if (!Prefab)
            {
                Debug.LogError(gameObject.name + ": [SpawnPrefab] No prefab added to be spwaned.");
                return;
            }
            if (SpawnOnStart)
            {
                SpawnObject();
            }
        }

        void OnDestroy()
        {
            if (_createdObjects != null)
            {
                foreach (var item in _createdObjects)
                {
                    Destroy(item);
                }
            }
        }

        public void SpawnObject()
        {
            var go = GameObject.Instantiate(Prefab, transform.position, Quaternion.identity, transform);
            if (_createdObjects == null)
                _createdObjects = new List<GameObject>();
            _createdObjects.Add(go);
        }
    }
}
