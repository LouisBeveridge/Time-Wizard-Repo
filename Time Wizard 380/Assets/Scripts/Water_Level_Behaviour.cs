using UnityEngine;
using System.Collections;

public class Water_Level_Behaviour : MonoBehaviour {

	public GameObject WaterLevel;

	private string pipeState;

	private float low = -10.84f;
	private float mid = -3.77f;
	private float high = 3453f;

	private Transform waterLevelTrans;

	// Use this for initialization
	void Start () {
		FindCurrentState ();
		waterLevelTrans = WaterLevel.transform;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateWaterLevelPos ();
	}


	//Function used to find which fan is currently meant to be active
	void FindCurrentState() {
		
		switch (gameObject.tag) {
			
		case "New":
			waterLevelTrans.position.Set(waterLevelTrans.position.x,low,waterLevelTrans.position.z);
			break;
			
		case "Mid":
			waterLevelTrans.position.Set(waterLevelTrans.position.x,mid,waterLevelTrans.position.z);
			break;
			
		case "Old":
			waterLevelTrans.position.Set(waterLevelTrans.position.x,high,waterLevelTrans.position.z);		
			break;
			
		default:
			print("something is broken with the CurrentState switch function");
			break;
			
		} // end CurrentState object setter switch
		
	}
	
	
	void OnTriggerEnter (Collider col){
		
		//-------------BACKWARDS TIME WARP---------------
		//Time warp worked
		if (col.gameObject.tag == "B_Warp") {
			
			switch (gameObject.tag) {
			case "Mid":
				waterLevelTrans.position.Set(waterLevelTrans.position.x,low,waterLevelTrans.position.z);
				break;
				
			case "Old":
				waterLevelTrans.position.Set(waterLevelTrans.position.x,mid,waterLevelTrans.position.z);		
				break;
				
			default:
				print("something is broken with the CurrentState switch function");
				break;
				
			} // end CurrentState object setter switch
			
			StartCoroutine ("proToNat");
		} else { //time warp didn't work
			
		}
		
		//-------------FORWARDS TIME WARP---------------
		if (col.gameObject.tag == "F_Warp") {

			switch (gameObject.tag) {
			case "Low":
				waterLevelTrans.position.Set(waterLevelTrans.position.x,mid,waterLevelTrans.position.z);
				break;
				
			case "Mid":
				waterLevelTrans.position.Set(waterLevelTrans.position.x,high,waterLevelTrans.position.z);		
				break;
				
			default:
				print("something is broken with the CurrentState switch function");
				break;
				
			} // end CurrentState object setter switch
			
			
			StartCoroutine ("postToNat");
		}

	}



//----------------------------START ENUMERATORS--------------------------------------------------
	IEnumerator preToNat() {
		yield return new WaitForSeconds (5);
		if (waterLevelTrans.position.y == mid) {
			waterLevelTrans.position.Set (waterLevelTrans.position.x, high, waterLevelTrans.position.z);
		} else {
			waterLevelTrans.position.Set (waterLevelTrans.position.x, mid, waterLevelTrans.position.z);
		}
	}

	IEnumerator postToNat() {
		yield return new WaitForSeconds (5);
		if (waterLevelTrans.position.y == high) {
			waterLevelTrans.position.Set (waterLevelTrans.position.x, mid, waterLevelTrans.position.z);
		} else {
			waterLevelTrans.position.Set (waterLevelTrans.position.x, low, waterLevelTrans.position.z);
		}
	}

//----------------------------END ENUMERATORS--------------------------------------------------

	

	void UpdateWaterLevelPos() {

	


	}//end UpdateWaterLevelPos

}
