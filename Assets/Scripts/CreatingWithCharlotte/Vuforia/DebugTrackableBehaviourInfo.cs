using System;
using System.Linq;
using UnityEngine;
using Vuforia;

namespace CreatingWithCharlotte.Vuforia
{
    [RequireComponent(typeof(TrackableBehaviour))]
    public class DebugTrackableBehaviourInfo : MonoBehaviour, ITrackableEventHandler
    {
        public event EventHandler<TrackableBehaviour> OnActiveStatusCalled;
        public TrackableBehaviour.Status[] ActiveStatuses = new TrackableBehaviour.Status[] { TrackableBehaviour.Status.TRACKED };
        private TrackableBehaviour _behaviour;

        void Start()
        {
            _behaviour = GetComponent<TrackableBehaviour>();
            if (_behaviour)
            {
                _behaviour.RegisterTrackableEventHandler(this);
            }
            else
            {
                Debug.LogError("Trackable Behaviour not found on this gameObject: " + gameObject.name);
            }
        }

        void OnDestroy()
        {
            if (_behaviour)
            {
                _behaviour.UnregisterTrackableEventHandler(this);
            }
        }

        public void OnTrackableStateChanged(
                                            TrackableBehaviour.Status previousStatus,
                                            TrackableBehaviour.Status newStatus)
        {
            Debug.Log(_behaviour.TrackableName + " " + newStatus.ToString());
            if (ActiveStatuses.Contains(newStatus))
            {
                OnActiveStatusCalled?.Invoke(this, _behaviour);
            }
        }
    }
}
