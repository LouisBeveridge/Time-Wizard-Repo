using UnityEngine;
using System.Collections;

public class Projectile_Behaviours : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 10f);
	}
	
	// Player Movement Variables/....
	public static int movespeed = 20;
	//public Vector3 userDirection = Vector3.left;
	
	public void Update()
	{
		transform.Translate(Vector3.forward * movespeed * Time.deltaTime); 
	}


}

