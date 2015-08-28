using UnityEngine;
using System.Collections;

public class HorMechArm : MonoBehaviour {
	
	
	public GameObject New_Pivot;
	public GameObject Mid_Pivot;
	public GameObject Old_Pivot;
	
	public GameObject CogNew1, CogNew2, CogMid1, CogMid2, CogOld1, CogOld2;
	
	//Individual fan behaviour modifiers. ADD MORE FOR EACH STAGE
	public float rotBreadth = 20f;
	public float rotSpeed = 0.5f;

	//temp storage for speed of mech arm
	private float previousSpeed;

	private float currentRotSpeed;
	private float currentRot = 0f;
	private float startingRot;	
	
	//cog speeds
	private float cogFast = 10f, cogMid = 5f, cogOld = 0f;
	//arm speeds
	private float armFast = 10f, armMid = 5f, armOld = 0f;
	
	public bool right = true;
	
	
	Transform newPivotTrans;
	Transform midPivotTrans;
	Transform oldPivotTrans;
	
	Transform platformTrans;
	
	
	
	
	
	
	// Use this for initialization
	void Start () {
		
		newPivotTrans = New_Pivot.transform;
		midPivotTrans = Mid_Pivot.transform;
		oldPivotTrans = Old_Pivot.transform;
		
		startingRot = midPivotTrans.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		//spin cogs
		SpinCogs ();
		//update current rot variable
		currentRot = midPivotTrans.eulerAngles.y;
		//move the mechanical arm
		rotate ();
		
	}
	
	void rotate() {
		
		if (right) {
			newPivotTrans.Rotate(Vector3.up * rotSpeed);
			midPivotTrans.Rotate(Vector3.up * rotSpeed);
			oldPivotTrans.Rotate(Vector3.up * rotSpeed);
			if(currentRot>=startingRot+rotBreadth) 
			{
				StartCoroutine("wait");
				right = false;
			}
		}//end up if
		else {
			newPivotTrans.Rotate(-Vector3.up * rotSpeed);
			midPivotTrans.Rotate(-Vector3.up * rotSpeed);
			oldPivotTrans.Rotate(-Vector3.up * rotSpeed);
			if(currentRot<startingRot-rotBreadth) 
			{
				StartCoroutine("wait");
				right = true;
			}
		}//end !up else
		
		
	}
	
	
	
	
	
	
	void OnTriggerEnter (Collider col){



		//-------------BACKWARDS TIME WARP---------------
		//Time warp worked
		if (col.gameObject.tag == "B_Warp") {
			
			rotSpeed = armFast;
			
			StartCoroutine ("speedNormaliser");
			rotSpeed = previousSpeed;
			cogFast = cogFast*-1000f;
			cogMid = cogMid*-1000f;
		} else { //time warp didn't work
			
		}
		
		//-------------FORWARDS TIME WARP---------------
		if (col.gameObject.tag == "F_Warp") {
			
			rotSpeed = armOld;
			
			StartCoroutine("speedNormaliser");
			rotSpeed = previousSpeed;
			cogFast = cogFast*-1000f;
			cogMid = cogMid*-1000f;
		}
		
		//-------------SLOW TIME WARP---------------  (implented in semester two)
		
		//
	} //end on trigger enter
	
	
	
	//--------------START ENUMERATORS--------------------------------------------
	IEnumerator speedNormaliser() {
		//wait for five seconds.
		yield return new WaitForSeconds(5);
		
		rotSpeed = armMid;
		
		
	}//end IEnumerator
	
	//used to pause the mechanical arm for a period of time after reaching it's limits
	IEnumerator wait() {


		rotSpeed = 0f;
		cogFast = cogFast/1000f;
		cogMid = cogMid/1000f;
		yield return new WaitForSeconds (1);
		rotSpeed = armFast;
		cogFast = cogFast*-1000f;
		cogMid = cogMid*-1000f;
	}
	// ------------------END ENUMERATORS---------------------------------------------
	
	
	void SpinCogs() {
		
		CogNew1.transform.Rotate(Vector3.up *cogFast);
		CogNew2.transform.Rotate(Vector3.down * cogFast);
		CogMid1.transform.Rotate(Vector3.up * cogMid);
		CogMid2.transform.Rotate(Vector3.down * cogMid);
		CogOld1.transform.Rotate(Vector3.up * cogOld);
		CogOld2.transform.Rotate(Vector3.down * cogOld);
		
	}
	
}

