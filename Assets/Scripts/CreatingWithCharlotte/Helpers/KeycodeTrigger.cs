using UnityEngine;
using UnityEngine.Events;
using System;

namespace CreatingWithCharlotte.Helpers
{
    public class KeycodeTrigger : MonoBehaviour
    {
        public KeyCode Key;
        public CustomEvent FunctionToTrigger;        

        void Update()
        {
            if (Input.GetKeyDown(Key) && FunctionToTrigger != null)
            {
                FunctionToTrigger.Invoke();
            }
        }
    }
    [Serializable]
    public class CustomEvent : UnityEvent
    {
    } 
}