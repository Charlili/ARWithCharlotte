using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;

namespace CreatingWithCharlotte.Vuforia
{
    public class DebugVuforiaInfo : MonoBehaviour
    {
        public bool ShowCameraName = true;
        public bool ShowCurrentlyTrackedBehaviour = true;
        private TMP_Text _text;
        private CameraDevice _cameraDevice;
        private VuforiaARController _vuforiaArController;
        private List<DebugTrackableBehaviourInfo> _activeInfos = new List<DebugTrackableBehaviourInfo>();
        private List<DebugTrackableBehaviourInfo> _newlyCreatedInfos = new List<DebugTrackableBehaviourInfo>();
        private string _cameraName = "", _currentActiveTrackableBehaviour = "";
        void Start()
        {
            _text = GetComponent<TMP_Text>();
            _cameraDevice = CameraDevice.Instance;
            _vuforiaArController = VuforiaARController.Instance;
            _vuforiaArController.RegisterVuforiaStartedCallback(OnVuforiaStarted);

        }

        private void OnDestroy()
        {
            _vuforiaArController.UnregisterVuforiaStartedCallback(OnVuforiaStarted);
            foreach (var item in _activeInfos)
            {
                item.OnActiveStatusCalled -= OnActiveTrackableBehaviourCalled;
            }
            foreach (var item in _newlyCreatedInfos)
            {
                Destroy(item);
            }
        }

        private void CreateDebugText()
        {
            var text = "";
            if (ShowCameraName)
            {
                text += "Camera name: " + _cameraName;
            }
            if (ShowCurrentlyTrackedBehaviour)
            {
                text += "\nCurrently tracked: " + _currentActiveTrackableBehaviour;
            }
        }
        private void OnVuforiaStarted()
        {
            var trackableBehaviours = FindObjectsOfType<TrackableBehaviour>();
            foreach (var item in trackableBehaviours)
            {
                var debug = item.GetComponent<DebugTrackableBehaviourInfo>();
                if (debug == null)
                {
                    debug = item.gameObject.AddComponent<DebugTrackableBehaviourInfo>();
                    _newlyCreatedInfos.Add(debug);
                }
                _activeInfos.Add(debug);
                debug.OnActiveStatusCalled += OnActiveTrackableBehaviourCalled;
            }
        }

        private void OnActiveTrackableBehaviourCalled(object sender, TrackableBehaviour e)
        {
            _currentActiveTrackableBehaviour = e.TrackableName;
            CreateDebugText();
        }
    }

}