using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	Animator animFade;                          // Reference to the animator component.

	
	void Awake ()
	{
		animFade = GetComponent <Animator> ();
	}
	
	
	void Update ()
	{
		if(Input.GetKeyDown ("e"))
		{
			//anim.ResetTrigger("FadeIn");
			animFade.Play("FadeIn");
		}
	}
}
