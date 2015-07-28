using UnityEngine;
using System.Collections;

public class Placeholderaimswitcher : MonoBehaviour {

	//Time Wizards reticles
	public GameObject LeftAim;
	public GameObject RightAim;

	public GameObject Fan1;
	public GameObject Fan2;
	public GameObject Pipe1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SwitchAim ();
	}

	void SwitchAim() {	
		if (Input.GetKey("1")) {
			LeftAim.transform.LookAt (Fan1.transform.position);
			RightAim.transform.LookAt (Fan1.transform.position);
			print ("Fan1");
			
		} else  if (Input.GetKey("2")) {
			LeftAim.transform.LookAt (Fan2.transform.position);
			RightAim.transform.LookAt (Fan2.transform.position);
			print ("Fan2");
			
		} else if (Input.GetKey("3")) {
			LeftAim.transform.LookAt (Pipe1.transform.position);
			RightAim.transform.LookAt (Pipe1.transform.position);
			print ("Pipe");
		}

	}


	
	void OnTriggerEnter(Collider col) {
		
		if (gameObject.tag == "FanMid") {
			LeftAim.transform.LookAt (Fan1.transform.position);
			RightAim.transform.LookAt (Fan1.transform.position);
			print ("Fan1");

		} else  if (gameObject.tag == "FanOld") {
			LeftAim.transform.LookAt (Fan2.transform.position);
			RightAim.transform.LookAt (Fan2.transform.position);
			print ("Fan2");

		} else if (gameObject.tag == "Pipe") {
			LeftAim.transform.LookAt (Pipe1.transform.position);
			RightAim.transform.LookAt (Pipe1.transform.position);
			print ("Pipe");
	}
}
}
