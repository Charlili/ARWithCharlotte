using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingWithCharlotte.Controllers
{
    public class WebcamController : MonoBehaviour
    {
        public bool UseFrontCamera = false;
        IEnumerator Start() {
            yield return new WaitForEndOfFrame();

            


        }
    } 
}
