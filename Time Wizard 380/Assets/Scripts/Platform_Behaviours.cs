using UnityEngine;
using System.Collections;

public class Platform_Behaviours : MonoBehaviour {
	
	public GameObject Splash;
	public GameObject Time_Wizard;
	Transform myTransform;


	private GameObject Splashclone;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Water") {

			Splashclone = (GameObject)Instantiate (Splash, transform.position, transform.rotation);
				}//end if

		if (col.gameObject.tag == "Player") {

			col.transform.parent = myTransform;
				}
		}


	
	
	void OnTriggerExit (Collider col) {
		if(col.gameObject.tag == "Player") {
			print("OFF");
			Destroy (Splashclone,2);
			col.transform.parent= null;

	}
}
}
