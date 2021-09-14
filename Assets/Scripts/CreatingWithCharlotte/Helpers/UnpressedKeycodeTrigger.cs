using UnityEngine;

namespace CreatingWithCharlotte.Helpers
{
    public class UnpressedKeycodeTrigger : MonoBehaviour
    {
        public KeyCode Key;
        public CustomEvent FunctionToTrigger;        

        void Update()
        {
            if (Input.GetKeyUp(Key) && FunctionToTrigger != null)
            {
                FunctionToTrigger.Invoke();
            }
        }
    }
}