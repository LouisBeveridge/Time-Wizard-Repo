using UnityEngine;
using System.Collections;

public class TimeWizardHealth : MonoBehaviour {
	

	//-------Health ---------
	// GUI objects
	public GameObject HealthHourGlass; 
	Animator healthAnim;
	//numerical health value
	public int health = 5;


	void Awake() {
		healthAnim = HealthHourGlass.GetComponent<Animator> ();
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

//----------------------------START TRIGGERS----------------------------------

	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Bite") {
			health--;
			healthAnim.SetInteger ("health", health);
		}//end HEALTH if
	
	}//end of ontriggerenter

//---------------------------END TRIGGERS-----------------------------------

}
