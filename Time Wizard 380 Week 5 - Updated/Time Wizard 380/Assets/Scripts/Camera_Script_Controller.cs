using UnityEngine;
using System.Collections;

public class Camera_Script_Controller : MonoBehaviour {

	public GameObject Target;

	private Transform target;


	// Use this for initialization
	void Start () {
		//initialise the Time Wizards location into a Transform variable;
		target = Target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		transform.Translate(Vector3.right * Time.deltaTime);
	
	}
}
