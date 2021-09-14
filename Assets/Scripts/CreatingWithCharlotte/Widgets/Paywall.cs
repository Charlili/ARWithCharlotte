using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingWithCharlotte.Widgets
{
    public class Paywall : MonoBehaviour
    {
        public float Duration = 10f;
        public List<GameObject> ObjectsToDisable = new List<GameObject>();
        public List<GameObject> ObjectsToEnable = new List<GameObject>();

        IEnumerator Start()
        {
            yield return new WaitForSeconds(Duration);
            print("Paywall activated");
            foreach (var item in ObjectsToDisable)
            {
                item.SetActive(false);
            }
            foreach (var item in ObjectsToEnable)
            {
                item.SetActive(true);
            }
        }
    }
}