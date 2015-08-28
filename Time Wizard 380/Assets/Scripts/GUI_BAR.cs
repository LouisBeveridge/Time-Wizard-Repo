using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_BAR : MonoBehaviour {
	
	public GameObject TimeWarpBar;
	public Image Lives;
	public Image Charges;
	//public ani
	private int timeWarpsLeft = 5;
	private int instaCranksLeft = 0;
	public int healthLeft = 5;
	private string numInput = "0"; //just for testing
	//Vector3 up = new Vector3 (0,1,0);
	//Vector3 down = new Vector3 (0,0,0);
	public Sprite zeroLife,oneLife,twoLife,threeLife,fourLife,fiveLife,  zeroCharge,oneCharge,twoCharge,threeCharge,fourCharge,fiveCharge;

	private bool canFire = true, crankable = true;
	Animator anim;

	Transform timeWarpTrans;
	
	// Use this for initialization
	void Start () {
		
		//timeWarpTrans = TimeWarpBar.transform;
		anim = GetComponent <Animator> ();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//ReadMessage();
		SetTimeWarpsLeft();
		UpdateBar ();


		if (Input.GetKey ("p")) {
			//animation.Play ("FadeIn");
			anim.SetTrigger ("FadeIn");
		}
	}
	
	void UpdateBar() {
		
		//	TimeWarpBar = //input from another script (set to a key binding for now)
		switch(timeWarpsLeft) {
			
		case 0://empty
			//transform.position = new Vector3(0,0,0);//transform the time warp bar to look like it has nothing left in it
			//In each case just destroy the old sprite and instantiate the new sprite with relevant information (timeWarpsleft integer)
			Charges.sprite = zeroCharge;
			break;
		case 1:
			//transform.position = new Vector3(0,1,0);//transform the time warp bar to look like it has nothing left in it
			Charges.sprite = oneCharge;

			break;
		case 2:
			//transform.position = new Vector3(0,2,0);//transform the time warp bar to look like it has nothing left in it
			Charges.sprite = twoCharge;
			break;
		case 3:
			//transform.position= new Vector3(0,3,0);//transform the time warp bar to look like it has nothing left in it
			Charges.sprite = threeCharge;
			break;
		case 4:
			//transform.position= new Vector3(0,4,0);//transform the time warp bar to look like it has nothing left in it
			Charges.sprite = fourCharge;
			break;
		case 5:
			//transform.position= new Vector3(0,5,0);//transform the time warp bar to look like it has nothing left in it
			Charges.sprite = fiveCharge;
			break;
		
			
		}//end of switch statement
		
		//	HealthBar = //input from another script (set to a key binding for now)
		switch(healthLeft) {
			
		case 0://empty
			//transform.position = new Vector3(0,0,0);//transform the time warp bar to look like it has nothing left in it
			//In each case just destroy the old sprite and instantiate the new sprite with relevant information (timeWarpsleft integer)
			Lives.sprite = zeroLife;
			break;
		case 1:
			//transform.position = new Vector3(0,1,0);//transform the time warp bar to look like it has nothing left in it
			Lives.sprite = oneLife;
			
			break;
		case 2:
			//transform.position = new Vector3(0,2,0);//transform the time warp bar to look like it has nothing left in it
			Lives.sprite = twoLife;
			break;
		case 3:
			//transform.position= new Vector3(0,3,0);//transform the time warp bar to look like it has nothing left in it
			Lives.sprite = threeLife;
			break;
		case 4:
			//transform.position= new Vector3(0,4,0);//transform the time warp bar to look like it has nothing left in it
			Lives.sprite = fourLife;
			break;
		case 5:
			//transform.position= new Vector3(0,5,0);//transform the time warp bar to look like it has nothing left in it
			Lives.sprite = fiveLife;
			break;
			
			
		}


	}

	//________Enumerators_____________________

	IEnumerator holdFire() {
		yield return new WaitForSeconds(1);
		canFire = true;
	}//end IEnumerator

	IEnumerator waitAnimationFinish() {
		//wait for five seconds.
		yield return new WaitForSeconds(2);
		crankable = true;
	}//end IEnumerator

//____________End Enumerators__________________



	
	void SetTimeWarpsLeft() { //just for testing

		if ((Input.GetKey ("q") || Input.GetAxis("Triggers") == 1) && timeWarpsLeft > 0 && canFire) {
			canFire = false;
			timeWarpsLeft = timeWarpsLeft-1;
			healthLeft = healthLeft-1;
			StartCoroutine("holdFire");
				}
		if ((Input.GetKey ("e") || Input.GetAxis("Triggers") == -1) && timeWarpsLeft > 0 && canFire) {
			canFire = false;
			timeWarpsLeft = timeWarpsLeft-1;
			StartCoroutine("holdFire");
		}


		//if statement to turn crank
		if (Input.GetKey("c") && crankable) {
			//spam prevention boolean
			crankable = false;
			//animation for cranking will be called here

			//Wait for animation
			StartCoroutine("waitAnimationFinish");
			timeWarpsLeft = timeWarpsLeft+1;
		}


		/* ________________________________________________________________
		 * Code Block for checking time warp HUD functionality


		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			timeWarpsLeft = 0;
				}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			timeWarpsLeft = 1;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			timeWarpsLeft = 2;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			timeWarpsLeft = 3;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			timeWarpsLeft = 4;
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			timeWarpsLeft = 5;
		}

		print (timeWarpsLeft);	
_______________________________________________________________________*/

	}



	
}



