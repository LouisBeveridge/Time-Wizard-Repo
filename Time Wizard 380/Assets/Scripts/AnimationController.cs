using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	Animator anim;

	private bool idling = true;
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		idling = true;

		//jump anim
		if (Input.GetKeyDown ("space") || Input.GetButtonDown ("Jump")) {
			anim.SetBool ("jump", true);
			idling =false;
		} else {
			anim.SetBool ("jump", false);
			//anim.SetBool ("idle", true);
		}

		//movement anim
		if ((Input.GetKeyDown ("w") || Input.GetAxis ("Vertical") > 0.2 || Input.GetAxis ("Vertical") < -0.2) ||
			(Input.GetKey ("a") || Input.GetAxis ("Horizontal") > 0.2 || Input.GetAxis ("Horizontal") < -0.2) ||
		    (Input.GetKey ("s")) || (Input.GetKey ("d"))) 
		{
			anim.SetBool ("walk", true);
			idling =false;
		} else {
			anim.SetBool("walk", false);
		//	anim.SetBool ("idle", true);
		}

		//left bell anim
		if (Input.GetKeyDown ("q") || (Input.GetAxis("Triggers") == 1)|| Input.GetButtonDown("leftBumper")) {
			anim.SetBool ("leftBell", true);
			idling =false;
		} else {
			anim.SetBool ("leftBell", false);
			//anim.SetBool ("idle", true);
		}

		//right bell anim
		if (Input.GetKeyDown ("e") || Input.GetKeyDown ("r") || (Input.GetAxis("Triggers") == -1) || Input.GetButtonDown("rightBumper")) {
			anim.SetBool ("rightBell", true);
			idling =false;
		} else {
			anim.SetBool ("rightBell", false);
			//anim.SetBool ("idle", true);
		}

		if (Input.GetKeyDown ("x") || Input.GetButton("yButton")) {
			anim.SetBool ("shimmer",true);
			idling = false;
		} else {
			anim.SetBool ("shimmer", false);


		}

		if (idling == true) {
			anim.SetBool ("idle",true);
		} else {
			anim.SetBool ("idle", false);
		}
		/*
		
		if (Input.GetKey ("q") || (Input.GetAxis("Triggers") == 1) && !GetComponent<Animation>().IsPlaying ("Jump")) {
			GetComponent<Animation>().Stop ("Idle");
			GetComponent<Animation>().Play ("LeftBell");
		} else if (Input.GetKey ("e") || (Input.GetAxis("Triggers") == -1) && !GetComponent<Animation>().IsPlaying ("Jump")) {
			GetComponent<Animation>().Stop ("Idle");
			GetComponent<Animation>().Play ("RightBell");
		}
		//|| (Input.GetAxis("Triggers") == 1)
		
		if (!GetComponent<Animation>().isPlaying){
			GetComponent<Animation>().Play ("Idle");
		}


















		//4 directions movement
		if (Input.GetKeyDown ("space") || Input.GetButton("Jump")) {
			
			GetComponent<Animation>().Stop ("Walk");
			GetComponent<Animation>().Stop ("Idle");
			GetComponent<Animation>().Play ("Jump");
			
		} else if ((Input.GetKey ("w") || Input.GetAxis ("Vertical") > 0.2 || Input.GetAxis ("Vertical") < -0.2) && !GetComponent<Animation>().IsPlaying ("Jump")) {
			GetComponent<Animation>().Play ("Walk");
		} else if ((Input.GetKey ("a") || Input.GetAxis ("Horizontal") > 0.2 || Input.GetAxis ("Horizontal") < -0.2) && !GetComponent<Animation>().IsPlaying ("Jump")) {
			GetComponent<Animation>().Play ("Walk");
		} else if (Input.GetKey ("d") && !GetComponent<Animation>().IsPlaying ("Jump")) {
			GetComponent<Animation>().Play ("Walk");
		} else if (Input.GetKey ("s") && !GetComponent<Animation>().IsPlaying ("Jump")) {
			GetComponent<Animation>().Play ("Walk");
		} else if (Input.GetKeyUp ("w") || (Input.GetAxis ("Vertical") < 0.2 && Input.GetAxis ("Vertical") > -0.2)) {
			GetComponent<Animation>().Stop ("Walk");
		} else if (Input.GetKeyUp ("s")) {
			GetComponent<Animation>().Stop ("Walk");
		} else if (Input.GetKeyUp ("a") || (Input.GetAxis ("Horizontal") < 0.2 && Input.GetAxis ("Horizontal") > -0.2)) {
			GetComponent<Animation>().Stop ("Walk");
		} else if (Input.GetKeyUp ("d")) {
			GetComponent<Animation>().Stop ("Walk");
		} 

		if (Input.GetKey ("q") || (Input.GetAxis("Triggers") == 1) && !GetComponent<Animation>().IsPlaying ("Jump")) {
			GetComponent<Animation>().Stop ("Idle");
			GetComponent<Animation>().Play ("LeftBell");
		} else if (Input.GetKey ("e") || (Input.GetAxis("Triggers") == -1) && !GetComponent<Animation>().IsPlaying ("Jump")) {
			GetComponent<Animation>().Stop ("Idle");
			GetComponent<Animation>().Play ("RightBell");
		}
		//|| (Input.GetAxis("Triggers") == 1)
		
		if (!GetComponent<Animation>().isPlaying){
			GetComponent<Animation>().Play ("Idle");
		}*/
		
	}//end update
}