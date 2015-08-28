using UnityEngine;
using System.Collections;

public class finishTutorial : MonoBehaviour {


	public GameObject dog1, dog2, dog3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag=="PlayerRigid") {
			Application.LoadLevel("Forest");
		}

	}
}
