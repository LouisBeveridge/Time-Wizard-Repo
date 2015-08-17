using UnityEngine;
using System.Collections;

public class Camerarotate : MonoBehaviour {
		
		public GameObject target;//the target object
		private float speedMod = 20.0f;//a speed modifier
		private Vector3 point;//the coord to the point where the camera looks at
		
		void Start () {//Set up things on the start method
			point = target.transform.position;//get target's coords
			
		}
		
		void Update () {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
		transform.LookAt(point);//makes the camera look to it
		Rotation ();
		}


	void Rotation() {
		//if (Input.GetKey ("o") || Input.GetAxis("RightStickHor") >= 0.5f) {
	//		transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * speedMod);
	//	}
		if (Input.GetKey ("o") || Input.GetAxis("RightStickVert") == 1) {
			transform.RotateAround (point,new Vector3(0.0f,0.0f,0.0f),20 * Time.deltaTime * -speedMod);

		}


	}
}
