using UnityEngine;
using System.Collections;

public class Grass_Behaviour : MonoBehaviour {

	Animator anim;

	//Use this for initialization-----------------------------------------------------
	void Start () {
	
		anim = GetComponent<Animator> ();

	}//end of start

	//Update is called once per frame-------------------------------------------------
	void Update () {
	


	}// end of update

	//-------------------------------------------------------------------------------
	void OnTriggerEnter(Collider col) {

	
			anim.SetBool("steppedOn", true);

	}//end of on trigger enter

	void OnTriggerExit(Collider col) {

			anim.SetBool("steppedOn", false);

	}//end of on trigger exit

}//EOF


