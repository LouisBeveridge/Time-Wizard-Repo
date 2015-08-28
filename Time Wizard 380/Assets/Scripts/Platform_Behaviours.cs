using UnityEngine;
using System.Collections;

public class Platform_Behaviours : MonoBehaviour {
	
	public GameObject Splash;
	private GameObject TimeWizard;
	Transform myTransform;


	private GameObject Splashclone;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
			
		TimeWizard = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Water") {

			//Splashclone = (GameObject)Instantiate (Splash, transform.position, transform.rotation);
				}//end if

		if (col.gameObject.tag == "PlayerRigid") {

			TimeWizard.transform.parent = myTransform;
				}
		}


	
	
	void OnTriggerExit (Collider col) {
		if(col.gameObject.tag == "PlayerRigid") {
			print("OFF");
		//	Destroy (Splashclone,2);
			TimeWizard.transform.parent= null;

	}
}
}
