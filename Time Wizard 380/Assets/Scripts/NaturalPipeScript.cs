using UnityEngine;
using System.Collections;

public class NaturalPipeScript : MonoBehaviour {
	
	/*
	//These gameobjects relate to the three game objects in the scene that the ObjectHandler script is switching between.
	public GameObject NewState;
	public GameObject MidState;
	public GameObject OldState;
	*/

	//public vaiables that determine the height of the water depending on the stage of the pipe.	
	public GameObject WaterLevel;
	public GameObject LowLevel;
	public GameObject MidLevel;
	public GameObject HighLevel;

	//private game objects referenced in the script. To be dynamically populated and updated with the public game objects.
	private GameObject PreLevel;
	private GameObject NaturalLevel;
	private GameObject PostLevel;

	private Transform waterLevelTrans;

	private bool natural= true;
	

	// Use this for initialization
	void Start () {
		waterLevelTrans = WaterLevel.transform;
		FindCurrentState ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Function used to find which fan is currently meant to be active
	void FindCurrentState() {
		
		switch (gameObject.tag) {
			
		case "New":
			PreLevel = null;
			NaturalLevel = LowLevel;
			PostLevel = MidLevel;
			waterLevelTrans.position = NaturalLevel.transform.position;
			break;
			
		case "Mid":
			PreLevel = LowLevel;
			NaturalLevel = MidLevel;
			PostLevel = HighLevel;	
			waterLevelTrans.position = NaturalLevel.transform.position;
			break;
			
		case "Old":
			PreLevel = MidLevel;
			NaturalLevel = HighLevel;
			PostLevel = null;	
			waterLevelTrans.position = NaturalLevel.transform.position;
			break;
			
		default:
			print("something is broken with the CurrentState switch function");
			break;
			
		} // end CurrentState object setter switch
		
	}


	void OnTriggerEnter (Collider col){

		//forwards time warp
		if (col.gameObject.tag == "F_Warp" && natural == true && gameObject.tag!="Old") { 
		
			natural = false;
			waterLevelTrans.position = PostLevel.transform.position;

			StartCoroutine("returnNatural");
				}

		//backwards time warp
		if (col.gameObject.tag == "B_Warp" && natural == true && gameObject.tag!="New") { 
			
			natural = false;
			waterLevelTrans.position = PreLevel.transform.position;
			
			StartCoroutine("returnNatural");
				}
		
	} //end on trigger enter

	IEnumerator returnNatural() {
		yield return new WaitForSeconds(5);
		waterLevelTrans.position = NaturalLevel.transform.position;

		natural = true;
		}//end IEnumerator





}
