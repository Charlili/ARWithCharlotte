using UnityEngine;

namespace CreatingWithCharlotte.Helpers
{
    public class OpenLink : MonoBehaviour
    {
        public string Link;

        public void Open()
        {
            Application.OpenURL(Link);
        }
    }

}