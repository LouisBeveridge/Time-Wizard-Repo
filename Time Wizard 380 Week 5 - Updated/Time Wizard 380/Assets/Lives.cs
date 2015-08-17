using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	Animator animLives;                          // Reference to the animator component.
	
	
	void Awake ()
	{
		animLives = GetComponent <Animator> ();
	}
	
	
	void Update ()
	{
		if(Input.GetKeyDown ("l"))
		{
			//anim.ResetTrigger("FadeIn");
			animLives.Play("Lives");
		}
	}
}
