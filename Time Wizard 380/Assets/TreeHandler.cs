using UnityEngine;
using System.Collections;

public class TreeHandler : MonoBehaviour {


	//tree parts
	public GameObject 
	//mid tree branches
	mb1, mb2, mb3, 
	//big tree branch
	bb4, bb5, bb6, bb7, bb8, bb9, bb10, bb11, bb12, bb13, bb14, bb15, bb16, bb17, bb18, bb19, bb20, bb21, bb22, 
	//sapling leaves
	sl1, sl2, sl3, 
	//sapling and mid tree trunk
	t1, 
	//mid and big tree leaves
	l1, l2, l3, l4, 
	//big tree leaves
	l5, l6, l7, l8, l9, l10;

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
			newSwitch();
			break;
			
		case "Mid":
			naturalState = mid;
			currentState = mid;
			midSwitch();
			break;
			
		case "Old":
			naturalState = big;
			currentState = big;
			bigSwitch ();
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
			if(naturalState==mid) {
				anim.SetInteger("currentState",big);
				bigSwitch();
			}
			else {
				//set the animation to be mid
				anim.SetInteger("currentState",mid);
				midSwitch();
			}
			
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
		if(naturalState==mid) {
			anim.SetInteger("currentState",mid);
			midSwitch();
		}
		else {
			anim.SetInteger("currentState",big);
			bigSwitch();
		}
		
		//turn ability to use time warp on puzzle object back on.
		warpable = true;
		
		
		
	}//end IEnumerator
	
	
	IEnumerator postToNatTREE() {
		//wait for five seconds.
		yield return new WaitForSeconds(5);
		
		//set the current state back to normal.
		if(naturalState==mid) {
			anim.SetInteger("currentState",mid);
			midSwitch();
		}
		else {
			anim.SetInteger("currentState",little);
			newSwitch();
		}
		
		//turn ability to use time warp on puzzle object back on.
		warpable = true;
		
	}//end IEnumerator
	//--------------END ENUMERATORS--------------------------------------------
	
	//------------------------------------------Collider and Mesh switch NEW------------------------------------------
	void newSwitch(){

		//mid branches
		mb1.GetComponent<MeshCollider> ().enabled = false;
		mb2.GetComponent<MeshCollider> ().enabled = false;
		mb3.GetComponent<MeshCollider> ().enabled = false;

		//big tree branch
		bb4.GetComponent<MeshCollider> ().enabled = false;
		bb5.GetComponent<MeshCollider> ().enabled = false;
		bb6.GetComponent<MeshCollider> ().enabled = false;
		bb7.GetComponent<MeshCollider> ().enabled = false;
		bb8.GetComponent<MeshCollider> ().enabled = false;
		bb9.GetComponent<MeshCollider> ().enabled = false;
		bb10.GetComponent<MeshCollider> ().enabled = false;
		bb11.GetComponent<MeshCollider> ().enabled = false;
		bb12.GetComponent<MeshCollider> ().enabled = false;
		bb13.GetComponent<MeshCollider> ().enabled = false;
		bb14.GetComponent<MeshCollider> ().enabled = false;
		bb15.GetComponent<MeshCollider> ().enabled = false;
		bb16.GetComponent<MeshCollider> ().enabled = false;
		bb17.GetComponent<MeshCollider> ().enabled = false;
		bb18.GetComponent<MeshCollider> ().enabled = false;
		bb19.GetComponent<MeshCollider> ().enabled = false;
		bb20.GetComponent<MeshCollider> ().enabled = false;
		bb21.GetComponent<MeshCollider> ().enabled = false;
		bb22.GetComponent<MeshCollider> ().enabled = false;

		//sapling leaf
		sl1.GetComponent<MeshCollider> ().enabled = true;
		sl2.GetComponent<MeshCollider> ().enabled = true;
		sl3.GetComponent<MeshCollider> ().enabled = true;

		//trunk
		t1.GetComponent<MeshCollider> ().enabled = true;

		//mid and big tree leaves
		l1.GetComponent<MeshCollider> ().enabled = false;
		l2.GetComponent<MeshCollider> ().enabled = false;
		l3.GetComponent<MeshCollider> ().enabled = false;
		l4.GetComponent<MeshCollider> ().enabled = false;

		//big tree leaves
		l5.GetComponent<MeshCollider> ().enabled = false;
		l6.GetComponent<MeshCollider> ().enabled = false;
		l7.GetComponent<MeshCollider> ().enabled = false;
		l8.GetComponent<MeshCollider> ().enabled = false;
		l9.GetComponent<MeshCollider> ().enabled = false;
		l10.GetComponent<MeshCollider> ().enabled = false;

	}//-------------------------------------------------end newSwitch--------------------------------------------------

	//------------------------------------------Collider and Mesh switch MID------------------------------------------
	void midSwitch(){
		
		//mid branches
		mb1.GetComponent<MeshCollider> ().enabled = true;
		mb2.GetComponent<MeshCollider> ().enabled = true;
		mb3.GetComponent<MeshCollider> ().enabled = true;
		
		//big tree branch
		bb4.GetComponent<MeshCollider> ().enabled = false;
		bb5.GetComponent<MeshCollider> ().enabled = false;
		bb6.GetComponent<MeshCollider> ().enabled = false;
		bb7.GetComponent<MeshCollider> ().enabled = false;
		bb8.GetComponent<MeshCollider> ().enabled = false;
		bb9.GetComponent<MeshCollider> ().enabled = false;
		bb10.GetComponent<MeshCollider> ().enabled = false;
		bb11.GetComponent<MeshCollider> ().enabled = false;
		bb12.GetComponent<MeshCollider> ().enabled = false;
		bb13.GetComponent<MeshCollider> ().enabled = false;
		bb14.GetComponent<MeshCollider> ().enabled = false;
		bb15.GetComponent<MeshCollider> ().enabled = false;
		bb16.GetComponent<MeshCollider> ().enabled = false;
		bb17.GetComponent<MeshCollider> ().enabled = false;
		bb18.GetComponent<MeshCollider> ().enabled = false;
		bb19.GetComponent<MeshCollider> ().enabled = false;
		bb20.GetComponent<MeshCollider> ().enabled = false;
		bb21.GetComponent<MeshCollider> ().enabled = false;
		bb22.GetComponent<MeshCollider> ().enabled = false;
		
		//sapling leaf
		sl1.GetComponent<MeshCollider> ().enabled = false;
		sl2.GetComponent<MeshCollider> ().enabled = false;
		sl3.GetComponent<MeshCollider> ().enabled = false;
		
		//trunk
		t1.GetComponent<MeshCollider> ().enabled = true;
		
		//mid and big tree leaves
		l1.GetComponent<MeshCollider> ().enabled = true;
		l2.GetComponent<MeshCollider> ().enabled = true;
		l3.GetComponent<MeshCollider> ().enabled = true;
		l4.GetComponent<MeshCollider> ().enabled = true;
		
		//big tree leaves
		l5.GetComponent<MeshCollider> ().enabled = false;
		l6.GetComponent<MeshCollider> ().enabled = false;
		l7.GetComponent<MeshCollider> ().enabled = false;
		l8.GetComponent<MeshCollider> ().enabled = false;
		l9.GetComponent<MeshCollider> ().enabled = false;
		l10.GetComponent<MeshCollider> ().enabled = false;
		
	}//-------------------------------------------------end midSwitch--------------------------------------------------

	//------------------------------------------Collider and Mesh switch OLD------------------------------------------
	void bigSwitch()
	{
		
		//mid branches
		mb1.GetComponent<MeshCollider> ().enabled = true;
		mb2.GetComponent<MeshCollider> ().enabled = true;
		mb3.GetComponent<MeshCollider> ().enabled = true;
		
		//big tree branch
		bb4.GetComponent<MeshCollider> ().enabled = true;
		bb5.GetComponent<MeshCollider> ().enabled = true;
		bb6.GetComponent<MeshCollider> ().enabled = true;
		bb7.GetComponent<MeshCollider> ().enabled = true;
		bb8.GetComponent<MeshCollider> ().enabled = true;
		bb9.GetComponent<MeshCollider> ().enabled = true;
		bb10.GetComponent<MeshCollider> ().enabled = true;
		bb11.GetComponent<MeshCollider> ().enabled = true;
		bb12.GetComponent<MeshCollider> ().enabled = true;
		bb13.GetComponent<MeshCollider> ().enabled = true;
		bb14.GetComponent<MeshCollider> ().enabled = true;
		bb15.GetComponent<MeshCollider> ().enabled = true;
		bb16.GetComponent<MeshCollider> ().enabled = true;
		bb17.GetComponent<MeshCollider> ().enabled = true;
		bb18.GetComponent<MeshCollider> ().enabled = true;
		bb19.GetComponent<MeshCollider> ().enabled = true;
		bb20.GetComponent<MeshCollider> ().enabled = true;
		bb21.GetComponent<MeshCollider> ().enabled = true;
		bb22.GetComponent<MeshCollider> ().enabled = true;
		
		//sapling leaf
		sl1.GetComponent<MeshCollider> ().enabled = false;
		sl2.GetComponent<MeshCollider> ().enabled = false;
		sl3.GetComponent<MeshCollider> ().enabled = false;
		
		//trunk
		t1.GetComponent<MeshCollider> ().enabled = true;
		
		//mid and big tree leaves
		l1.GetComponent<MeshCollider> ().enabled = true;
		l2.GetComponent<MeshCollider> ().enabled = true;
		l3.GetComponent<MeshCollider> ().enabled = true;
		l4.GetComponent<MeshCollider> ().enabled = true;
		
		//big tree leaves
		l5.GetComponent<MeshCollider> ().enabled = true;
		l6.GetComponent<MeshCollider> ().enabled = true;
		l7.GetComponent<MeshCollider> ().enabled = true;
		l8.GetComponent<MeshCollider> ().enabled = true;
		l9.GetComponent<MeshCollider> ().enabled = true;
		l10.GetComponent<MeshCollider> ().enabled = true;
		
	}//-------------------------------------------------end oldSwitch--------------------------------------------------
	

}
