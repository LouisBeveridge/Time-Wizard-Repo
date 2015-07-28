using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
		}
		
	}
}