using UnityEngine;
using System.Collections;

public class MechArmBehaviour : MonoBehaviour {


	public GameObject Cog1, Cog2;

	// Use this for initialization
	void Start () {




	}

	
	// Update is called once per frame
	void Update () {
	switch (gameObject.tag) {
		
	case "ArmMid":
		Cog1.transform.Rotate(Vector3.up *10);
		Cog2.transform.Rotate(Vector3.down * 10);
		break;
	}
			
		}//end switch
}
