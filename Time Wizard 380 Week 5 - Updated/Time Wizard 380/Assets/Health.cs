using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	Animator animHealth;                          // Reference to the animator component.
	
	
	void Awake ()
	{
		animHealth = GetComponent <Animator> ();
	}
	
	
	void Update ()
	{		
		if(Input.GetKeyDown ("h"))
		{
			//anim.ResetTrigger("FadeIn");
			animHealth.Play("Health");
		}
	}
}
