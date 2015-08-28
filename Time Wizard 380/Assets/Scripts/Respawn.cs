using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public GameObject DefaultSpawn;
	public GameObject TimeWizard, TWizModel;

	Animator anim;

	GameObject RespawnPoint;



	// Use this for initialization
	void Start () {
		RespawnPoint = DefaultSpawn;
		anim = TWizModel.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) { 


		if (col.gameObject.tag == "Water") {

			gameObject.GetComponent<ThirdPersonShooter>().enabled = false;
			anim.SetBool("drown", true);

			StartCoroutine("deathWait");




		}//end water if

		if (col.gameObject.tag == "Respawn") {

			RespawnPoint.transform.position = col.gameObject.transform.position;
			RespawnPoint.transform.rotation = col.gameObject.transform.rotation;
		}//end Respawn if





	}//end on trigger enter

	IEnumerator deathWait() {
		//wait for five seconds.
		yield return new WaitForSeconds (3);

		anim.SetBool ("drown", false);
		gameObject.GetComponent<ThirdPersonShooter>().enabled = true;
		TimeWizard.transform.position = RespawnPoint.transform.position;
		TimeWizard.transform.rotation = RespawnPoint.transform.rotation;
	}//end death wait


}
