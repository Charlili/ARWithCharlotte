using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationTransition : MonoBehaviour
{
	public Animator Animator;
	public string TriggerKey;
	public string BoolKey;
    
	public void SetTrigger(){
		if (Animator == null)
			return;
		Animator.SetTrigger (TriggerKey);
	}

	public void SetBool(bool isOn){
		if (Animator == null)
			return;
		Animator.SetBool (BoolKey, isOn);
	}
}
