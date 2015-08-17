using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GUI_BAR GuiBar;


	//Object references used for transform positions and particle instantiation
	public GameObject Left_Bell;
	public GameObject Right_Bell;
	public GameObject Body;
	public GameObject MainCamera;
	public GameObject BackwardsWarp;
	public GameObject ForwardsWarp;
	public GameObject LeftReticle;
	public GameObject RightReticle;
	public GameObject TimeWarpSound;

	public GameObject LeftBellParticles, RightBellParticles;

	private bool canFire = true;

	Transform camTrans;

	private Vector3 Target;

	private RaycastHit hit;
	private Ray projectileAim;

	// Use this for initialization
	void Start () {
		camTrans = MainCamera.transform;
		projectileAim = new Ray (camTrans.position, camTrans.forward); 
	}
	
	// Update is called once per frame
	void Update () {
		ShootWarp ();
		print (canFire);
		Debug.DrawRay (camTrans.position,camTrans.forward*100, Color.blue);
		GetHitTrans ();


	}

	void ShootWarp()
	{


		if ((Input.GetKey ("q") || Input.GetAxis("Triggers") == 1) && canFire == true) {
			canFire = false;
			GetHitTrans();
			GameObject shot = (GameObject)Instantiate(BackwardsWarp,Left_Bell.transform.position,Quaternion.Euler(LeftReticle.transform.forward));
			shot.transform.forward = LeftReticle.transform.forward;
			StartCoroutine("wait");
				}//end if

		if ((Input.GetKey ("e") || Input.GetAxis("Triggers") ==-1) && canFire == true) {
			canFire= false;
			GetHitTrans();
			GameObject shot = (GameObject)Instantiate(ForwardsWarp,Right_Bell.transform.position,Quaternion.Euler(RightReticle.transform.forward));
			shot.transform.forward = RightReticle.transform.forward;
			StartCoroutine("wait");
		}//end if
	}


	 private void GetHitTrans() {
		hit = new RaycastHit ();
		projectileAim = new Ray (camTrans.position, camTrans.forward); 

		if (Physics.Raycast (projectileAim, out hit, Mathf.Infinity)) {
			print("Raycast is hitting" + hit.point.ToString() + " the object is: " + hit.collider.gameObject.name);

			if(hit.collider.gameObject.tag == "New"){
				RightBellParticles.SetActive(true);
				LeftBellParticles.SetActive(false);
			} else if(hit.collider.gameObject.tag == "Mid"){
				RightBellParticles.SetActive(true);
				LeftBellParticles.SetActive(true);
			} else if(hit.collider.gameObject.tag == "Old"){
				RightBellParticles.SetActive(false);
				LeftBellParticles.SetActive(true);
			} else {
				RightBellParticles.SetActive(false);
				LeftBellParticles.SetActive(false);
			}

			LeftReticle.transform.LookAt (hit.point);
			RightReticle.transform.LookAt (hit.point);
		}
	}



// //end on trigger enter

IEnumerator wait() {
	yield return new WaitForSeconds(1);
		canFire = true;
}//end IEnumerato



}
