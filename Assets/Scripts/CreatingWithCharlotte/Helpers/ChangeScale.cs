using UnityEngine;

namespace CreatingWithCharlotte.Helpers
{
    public class ChangeScale : MonoBehaviour
    {
        public Vector3 HighlightedScale = new Vector3(1f, 0.1f, 1f);
        public float ChangingSpeed = 0.1f;
        private Vector3 _defaultScale = new Vector3(1f, 0.8f, 1f);
        private Vector3 _targetScale = new Vector3(1f, 0.8f, 1f);


        void OnEnable()
        {
            _defaultScale = transform.localScale;
        }

        void Update()
        {
            if (transform.localScale != _targetScale)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, ChangingSpeed);
            }
        }

        void OnMouseOver()
        {
            SetHighlightScale();
        }

        public void SetHighlightScale()
        {
            _targetScale = HighlightedScale;
        }

        public void SetDefaultScale()
        {
            _targetScale = _defaultScale;
        }
    }
}
