using UnityEngine;
using System.Collections;

public class Fan_Behaviour : MonoBehaviour {

	public GameObject Time_Wizard;
	Transform myTransform;
	float timeWizardTrans;

	public GameObject FanNew;
	public GameObject FanMid;
	public GameObject FanOld;
	public GameObject Blades;
	public GameObject Particles;
	

	private bool natural = true;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;

	}
	
	// Update is called once per frame
	void Update () {
		spinBlades ();
	}

	void OnTriggerStay(Collider col){

				if (col.gameObject.tag == "Player") {
		//	col.transform.Translate(Vector3.up * 15 * Time.deltaTime);
			col.transform.position = Vector3.Lerp (col.transform.position, new Vector3(col.transform.position.x, col.transform.position.y+5, col.transform.position.z), Time.deltaTime *2);
						}
				}
		




	void spinBlades() {

		if (gameObject.tag == "FanNew") {
			Blades.transform.Rotate(0,1080 * Time.deltaTime, 0);
			Particles.transform.Rotate(0, 0, 1080 * Time.deltaTime);
				}
		if (gameObject.tag == "FanMid") {
			Blades.transform.Rotate(0,420 * Time.deltaTime, 0);
			Particles.transform.Rotate(0, 0, 420 * Time.deltaTime);
		}
		if (gameObject.tag == "FanOld") {
			Blades.transform.Rotate(0,20 * Time.deltaTime, 0);
			Particles.transform.Rotate(0, 0, 20 * Time.deltaTime);
		}


	}



}
	



/*public class SmoothPosition : MonoBehaviour
{
	public Vector3 targetPosition;
	public Quaternion targetRotation; //Optional of course
	public float smoothFactor = 2;
	
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothFactor);
	}
}
*/



//	void OnTriggerExit(Collider col){
//		if (col.gameObject.tag == "Player") {
//			col.transform.Translate (Vector3.zero);

	



//__________________________________

