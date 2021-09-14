using UnityEngine;
using UnityEngine.UI;

namespace CreatingWithCharlotte.Helpers
{
    public class ChangeColor : MonoBehaviour
    {
        public Color HighlightColor = Color.red;
        private Color _defaultColor = Color.white;
        private Material _mat;
        private MaskableGraphic _image;
        private bool _useMaskableGraphic = false;

        void OnEnable()
        {
            _image = GetComponent<MaskableGraphic>();
            _mat = GetComponent<Renderer>()?.material;
            if (_image != null)
            {
                _useMaskableGraphic = true;
            }
            GetDefaultColor();
            SetDefaultColor();
        }

        //void OnMouseOver(){
        //	SetHighlightColor();
        //}

        //void OnMouseExit(){
        //	SetDefaultColor();
        //}


        public void SetHighlightColor()
        {
            if (_useMaskableGraphic)
            {
                _image.color = HighlightColor;
            }
            else
            {
                _mat.SetColor("_Color", HighlightColor);
            }
        }

        public void SetDefaultColor()
        {
            if (_useMaskableGraphic)
            {
                _image.color = _defaultColor;
            }
            else
            {
                _mat.SetColor("_Color", _defaultColor);
            }
        }

        private void GetDefaultColor()
        {
            if (_useMaskableGraphic)
            {
                _defaultColor = _image.color;
            }
            else
            {
                _defaultColor = _mat.color;
            }
        }
    }

}