using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public Transform Target;
	public bool UsePosition, UseRotation, UseScale, KeepOffset;
	private Vector3 _localOffsetPos, _localOffsetRot, _localOffsetScale;
	
    void Awake()
    {
		_localOffsetPos = Target.position - transform.position;
		_localOffsetRot = Target.eulerAngles - transform.eulerAngles;
		_localOffsetScale = Target.localScale - transform.localScale;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		if (Target == null) {
			return;
		}
		if (UsePosition) {
			transform.position = Target.position;
			if(KeepOffset){
				transform.position = Target.position - _localOffsetPos;
			}
		}
		if (UseRotation) {
			transform.eulerAngles = Target.eulerAngles;
			if(KeepOffset){
				transform.eulerAngles = Target.eulerAngles - _localOffsetRot;
			}
		}
		if (UseScale) {
			transform.localScale = Target.localScale;
			if(KeepOffset){
				transform.localScale = Target.localScale - _localOffsetScale;
			}
		}
    }

	public void ToggleRotation(){
		UseRotation = !UseRotation;
	}

	public void TogglePosition(){
		UsePosition = !UsePosition;
	}
}
