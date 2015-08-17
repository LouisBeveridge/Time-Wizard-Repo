using UnityEngine;
using System.Collections;

public class MechanicalArmHandler : MonoBehaviour {

	//reference to the animator controlling the arm and cogs
	private Animator anim;

	//is the arm moving vertial?
	public bool vertical;

	private bool warpable = true;

	//int:naturalState used to numerate the state the arm is in (1,2,3 - fast,mid,slow).
	private int naturalState = 0, fast = 1, mid = 2, slow = 3;  

	//arm/cog speed modifier + multipliers
	private float fastMult = 2f, midMult = 1f, slowMult = 0f;

	// Use this for initialization
	void Start () {
	
		//Gain access to the arm and cog animator
		anim = GetComponent<Animator> ();



		//switch statement to populate the int "naturalState" with a valid state (1, 2, or 3)
		switch (gameObject.tag) {
			
		case "New":
			naturalState = fast;
			anim.SetFloat ("speedMultiplier", fastMult);
			break;
			
		case "Mid":
			naturalState = mid;
			anim.SetFloat ("speedMultiplier", midMult);
			break;
			
		case "Old":
			naturalState = slow;
			anim.SetFloat ("speedMultiplier", slowMult);
			break;
			
		default:
			print ("something is broken with the naturaltState switch function");
			break;
		}//End of Switch Statement
	
		//set up the animators parametres
		anim.SetBool ("vertical", vertical);

	


	}//End of Start()
	
	// Update is called once per frame
	void Update () {

		/*if (vertical) {
			anim.SetFloat ("speedMultiplier", 5f);
		} else {
			anim.SetFloat ("speedMultiplier", 0f);
		}*/
	
	}//End of Update()


	void OnTriggerEnter (Collider col){
		
		//-------------BACKWARDS TIME WARP---------------
		//Time warp worked
		if (col.gameObject.tag == "B_Warp" && naturalState>1 && warpable) {

			//deactivate trigger
			warpable = false;

			//set the multipler to the warp befores speed.
			if(naturalState==mid) {anim.SetFloat("speedMultiplier",fastMult);}
			else {anim.SetFloat("speedMultiplier",midMult);}

			StartCoroutine ("preToNatARM");
		} else { //time warp didn't work
			
		}
		
		//-------------FORWARDS TIME WARP---------------
		if (col.gameObject.tag == "F_Warp" && naturalState<3 && warpable) {

			//deactivate trigger
			warpable = false;

			//set the multipler to the warp infronts speed.
			if(naturalState==mid) {anim.SetFloat("speedMultiplier",slowMult);}
			else {anim.SetFloat("speedMultiplier",midMult);}
			
			StartCoroutine("postToNatARM");
		}
		
		//-------------SLOW TIME WARP---------------  (implented in semester two)
		
		//
	}

	//--------------START ENUMERATORS--------------------------------------------
	IEnumerator preToNatARM() {
		//wait for five seconds.
		yield return new WaitForSeconds(5);

		//set the multipler back to normal.
		if(naturalState==slow) {anim.SetFloat("speedMultiplier",slowMult);}
		else {anim.SetFloat("speedMultiplier",midMult);}

		//turn ability to use time warp on puzzle object back on.
		warpable = true;

		
		
	}//end IEnumerator
	
	
	IEnumerator postToNatARM() {
		//wait for five seconds.
		yield return new WaitForSeconds(5);

		//set the multipler back to normal.
		if(naturalState==fast) {anim.SetFloat("speedMultiplier",fastMult);}
		else {anim.SetFloat("speedMultiplier",midMult);}
		
		//turn ability to use time warp on puzzle object back on.
		warpable = true;

	}//end IEnumerator
	//--------------END ENUMERATORS--------------------------------------------
		








}//EOF
