using UnityEngine;
using System.Collections;

public class TreeHandler : MonoBehaviour {

	//reference to the animator controlling the tree stages
	private Animator anim;

	//particles that go off when a time warp occurs
	public GameObject B_Particles;
	public GameObject F_Particles;

	//store the time state of the tree in numerical form
	private int naturalState = 0, currentState = 0 , little = 1, mid = 2, big = 3;

	//speedmultiplier for animation (determines if animation is playing or not
	private float speedMulitplier = 0f, on = 2f, off = 0f;

	//bool value that stops time warps from doing anything should a warp already be happening
	private bool warpable = true;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();




		//switch statement to populate the int "naturalState" with a valid state (1, 2, or 3)
		switch (gameObject.tag) {
			
		case "New":
			naturalState = little;
			currentState = little;
			break;
			
		case "Mid":
			naturalState = mid;
			currentState = mid;
			break;
			
		case "Old":
			naturalState = big;
			currentState = big;
			break;
			
		default:
			print ("something is broken with the naturalState switch function");
			break;
		}//End of Switch Statement

		//update the animator with the natural state.
		anim.SetInteger ("naturalState", naturalState);
		anim.SetInteger ("currentState", naturalState);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
	void OnTriggerEnter (Collider col){
		
		//-------------BACKWARDS TIME WARP---------------
		//Time warp worked
		if (col.gameObject.tag == "B_Warp" && naturalState>1 && warpable) {
			
			//deactivate trigger
			warpable = false;


			
			//set the multipler to the warp befores speed.
			if(naturalState==mid) {anim.SetInteger("currentState",little);}
			else {anim.SetInteger("currentState",mid);}
			
			StartCoroutine ("preToNatTREE");
		} else { //time warp didn't work
			
		}
		
		//-------------FORWARDS TIME WARP---------------
		if (col.gameObject.tag == "F_Warp" && naturalState<3 && warpable) {
			
			//deactivate trigger
			warpable = false;
			
			//set the multipler to the warp infronts speed.
			if(naturalState==mid) {anim.SetInteger("currentState",big);}
			else {anim.SetInteger("currentState",mid);}
			
			StartCoroutine("postToNatTREE");
		}
		
		//-------------SLOW TIME WARP---------------  (implented in semester two)
		
		//
	}
	
	//--------------START ENUMERATORS--------------------------------------------
	IEnumerator preToNatTREE() {
		//wait for five seconds.
		yield return new WaitForSeconds(5);
		
		//set the current state back to normal.
		if(naturalState==mid) {anim.SetInteger("currentState",mid);}
		else {anim.SetInteger("currentState",big);}
		
		//turn ability to use time warp on puzzle object back on.
		warpable = true;
		
		
		
	}//end IEnumerator
	
	
	IEnumerator postToNatTREE() {
		//wait for five seconds.
		yield return new WaitForSeconds(5);
		
		//set the current state back to normal.
		if(naturalState==mid) {anim.SetInteger("currentState",mid);}
		else {anim.SetInteger("currentState",little);}
		
		//turn ability to use time warp on puzzle object back on.
		warpable = true;
		
	}//end IEnumerator
	//--------------END ENUMERATORS--------------------------------------------
	



}
