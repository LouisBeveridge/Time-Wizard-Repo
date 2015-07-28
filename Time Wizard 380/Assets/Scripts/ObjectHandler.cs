using UnityEngine;
using System.Collections;

public class ObjectHandler : MonoBehaviour {

	//These gameobjects relate to the three game objects in the scene that the ObjectHandler script is switching between.
	public GameObject NewState;
	public GameObject MidState;
	public GameObject OldState;

	public GameObject B_Particles;
	public GameObject F_Particles;
	//public GameObject S_Particles;

	/*
	//These Game Object are Pipe Object exclusive.
	GameObject WaterLevel;
	public GameObject LevelLow;
	public GameObject LevelMid;
	public GameObject LevelHigh;*/

	public AudioClip TimeWarpWorked;
	public AudioClip TimeWarpFailed;

	//private game objects referenced in the script. To be dynamically populated and updated with the public game objects.
	private GameObject PreState;
	private GameObject NaturalState;
	private GameObject PostState;

	private GameObject particles;

	private AudioSource Sound;

	private bool natural = true;






	// Use this for initialization
	void Start () {
		//initialize the state of the  private gameobjects
		FindCurrentState ();
	//	naturalTag = gameObject.tag;
		//initialize the Audio Source var
		Sound = gameObject.GetComponent<AudioSource>();
		Sound.Stop ();


	}
	
	// Update is called once per frame
	void Update () {

	}


	//Function used to find which fan is currently meant to be active
	void FindCurrentState() {

		switch (gameObject.tag) {

		case "New":

			PreState = null;
			NaturalState = NewState;
			PostState = MidState;
			break;

		case "Mid":
			PreState = NewState;
			NaturalState = MidState;
			PostState = OldState;	
			break;

		case "Old":
			PreState = MidState;
			NaturalState = OldState;
			PostState = null;	
			break;

		default:
			print("something is broken with the FindCurrentState switch function");
			break;

		} // end CurrentState object setter switch

	}

	
	void OnTriggerEnter (Collider col){

		//-------------BACKWARDS TIME WARP---------------
		//Time warp worked
		if (col.gameObject.tag == "B_Warp" && PreState != null && natural) {

			Destroy(col.gameObject);

			//turn particles on
			B_Particles.SetActive(true);

			//Make cool noise
			Sound.PlayOneShot(TimeWarpWorked);

			//Make the natural object disabled.
			NaturalState.SetActive (false);

			//make the PreStateObject active.
			PreState.SetActive (true);

			//turn off the ability to trigger the Puzzle Object again while in an unnatural time state.
			natural = false;
		
			StartCoroutine ("preToNat");
		} else { //time warp didn't work

		}

		//-------------FORWARDS TIME WARP---------------
		if (col.gameObject.tag == "F_Warp" && PostState != null && natural) {

			Destroy(col.gameObject);

			//turn particles on
			F_Particles.SetActive(true);

			//Make cool noise
			Sound.PlayOneShot(TimeWarpWorked);
		
			//Make the natural object disabled.
			NaturalState.SetActive(false);
			
			//make the PreStateObject active.
			PostState.SetActive(true);
			
			//turn off the ability to trigger the Puzzle Object again while in an unnatural time state.
			natural = false;
			
			StartCoroutine("postToNat");
		}

		//-------------SLOW TIME WARP---------------  (implented in semester two)
		
		//
	} //end on trigger enter




//--------------START ENUMERATORS--------------------------------------------
	IEnumerator preToNat() {
		//wait for five seconds.
		yield return new WaitForSeconds(5);

		//Switch the active object from Pre to Natural.
		PreState.SetActive(false);
		NaturalState.SetActive(true);

		//turn ability to use time warp on puzzle object back on.
		natural = true;

		//turn particles off
		B_Particles.SetActive(false);


	}//end IEnumerator


	IEnumerator postToNat() {
		//wait for five seconds.
		yield return new WaitForSeconds(5);
		
		//Switch the active object from Post to Natural.
		PostState.SetActive(false);
		NaturalState.SetActive(true);
		
		//turn ability to use time warp on puzzle object back on.
		natural = true;

		//turn particles off
		F_Particles.SetActive(false);
	}//end IEnumerator
//--------------END ENUMERATORS--------------------------------------------

}
