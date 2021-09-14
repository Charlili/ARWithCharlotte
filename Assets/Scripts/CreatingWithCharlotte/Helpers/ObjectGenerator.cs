using System.Collections.Generic;
using UnityEngine;

namespace CreatingWithCharlotte.Helpers
{
    public class ObjectGenerator : MonoBehaviour
    {
        public GameObject Prefab;
        public float Interval = 80;
        private float _timer;
        private List<GameObject> _spawnedGameObjects = new List<GameObject>();
        void Update()
        {
            _timer += 1f;
            //print(_timer);
            if (_timer % Interval == 0)
            {
                CheckAndDestroySpheres();
                var g = GameObject.Instantiate(Prefab, transform);
                _spawnedGameObjects.Add(g);
            }
            //failsafe to make sure the _timer variable doesn't run out of memory / get too big
            if (_timer > 100000)
            {
                _timer = 0;
            }
        }

        private void CheckAndDestroySpheres()
        {
            if (_spawnedGameObjects.Count > 50)
            {
                var length = _spawnedGameObjects.Count - 5;
                for (int i = 0; i < length; i++)
                {
                    Destroy(_spawnedGameObjects[length - 1 - i]);
                    _spawnedGameObjects.RemoveAt(length - 1 - i);
                }
                print("Now only " + _spawnedGameObjects.Count + " objects remain. " + transform.childCount);
            }
        }
    } 
}
