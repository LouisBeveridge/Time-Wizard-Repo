using UnityEngine;
using System.Collections;

public class Water_Behaviour : MonoBehaviour {

	public GameObject Fireworks;


	// Use this for initialization
	void Start () {

	}



	void Update() 
	{

	}

	//DEATH TRIGGER
	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Player") {
			//Application.LoadLevel(0);
			print("Dickbutt");
						//Destroy (this.gameObject);

				}
	}
}

