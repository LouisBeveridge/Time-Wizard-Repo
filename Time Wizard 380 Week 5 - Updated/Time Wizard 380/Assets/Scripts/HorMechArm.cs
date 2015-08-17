using UnityEngine;
using System.Collections;

public class HorMechArm : MonoBehaviour {

		
		public GameObject Arm_Pivot;

		//Individual fan behaviour modifiers. ADD MORE FOR EACH STAGE
		public float rotBreadth = 20f;
		public float rotSpeed = 0.5f;

		private float currentRot = 0;
		private float startingRot;	


		private bool up = true;
		Transform pivotTrans;
		Transform platformTrans;
		

		
		

		
		// Use this for initialization
		void Start () {
			
		pivotTrans = Arm_Pivot.transform;
		startingRot = pivotTrans.eulerAngles.y;
		}
		
		// Update is called once per frame
		void Update () {
			
			//update current rot variable
			currentRot = pivotTrans.eulerAngles.y;
			//move the mechanical arm
			rotate ();
			
		}
		
		void rotate() {
			
			if (up) {
				pivotTrans.Rotate(Vector3.up * rotSpeed);

				if(currentRot>=startingRot+rotBreadth) 
				{
				StartCoroutine("wait");
					up = false;
				}
					}//end up if
						else {
							pivotTrans.Rotate(-Vector3.up * rotSpeed);
							if(currentRot<startingRot-rotBreadth) 
								{
								StartCoroutine("wait");
								up = true;
								}
							}//end !up else
			
			
		}
		

	//used to pause the mechanical arm for a period of time after reaching it's limits
	IEnumerator wait() {

		rotSpeed = 0f;
		yield return new WaitForSeconds (1);
		rotSpeed = 0.5f;

	}

}

