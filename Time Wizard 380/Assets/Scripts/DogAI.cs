using UnityEngine;
using System.Collections;

public class DogAI : MonoBehaviour {
	
	private Transform myTransform;
	public GameObject DogRaycast;

	//Case for what age of dog
	public int wolfStage = 1;

	// old dog to orbit, and the targeter to keep them in a neat circle
	public GameObject oldDog;

	//young pup rally point, for when they cant see the player
	public GameObject RallyPoint;
	public bool Resting = false;

	//Aka, enemy in the view of the dog
	public GameObject enemyPlayer;
	
	//Range that dogs engage player at (young)
	private float range = 100000.0f;

	//adult
	public float AdultRange = 10.0f;
	public float AdultAttackRange = 7.0f;
	//old
	public float oldRange = 7.0f;

	//Dog speed
	public float walkSpeed = 2.0f;

	//Rotation Variables
	public float rotationSpeed = 3.0f;
	private float adjRotSpeed;
	private Quaternion targetRotation;
	
	// Use this for initialization
	void Start () {
		myTransform = this.transform;
		//enemyPlayer.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		switch(wolfStage){ 
		case 1: puppyBehaviour(); 
			break;
		case 2: adultBehaviour();
			break;
		case 3: oldBehaviour();
			break;
		default: break;
		}
		

	}


	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == ("RallyPoint")) {
			walkSpeed = 0.0f;
			print ("working");
			Resting = true;
		}

	}

	void puppyBehaviour() {
		//Raycast Detection
		RaycastHit hit;
		if (Physics.Raycast (DogRaycast.transform.position, -(DogRaycast.transform.position - enemyPlayer.transform.position).normalized, out hit, range)) {
			
			//If hit has "Player" tag...
			if (hit.transform.tag == "Player") {

				walkSpeed = 2.0f;
				
				//Track Player - Linear Interpolation (LERP)
				targetRotation = Quaternion.LookRotation (enemyPlayer.transform.position - myTransform.position);
				//dog cannot rotate on its x axis (cannot look up)
				targetRotation.x = 0;
				adjRotSpeed = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
				myTransform.rotation = Quaternion.Lerp (myTransform.rotation, targetRotation, adjRotSpeed);

				//Move forwards
				transform.Translate (Vector3.forward * Time.deltaTime * walkSpeed);

				//Draw red debug line
				Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.red);
			} else {


					walkSpeed = 0.4f;

					//Draw green debug line
					Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.green);
					//Track Player - Linear Interpolation (LERP)
					targetRotation = Quaternion.LookRotation (RallyPoint.transform.position - myTransform.position);
					//dog cannot rotate on its x axis (cannot look up)
					targetRotation.x = 0;
					adjRotSpeed = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
					myTransform.rotation = Quaternion.Lerp (myTransform.rotation, targetRotation, adjRotSpeed);

					transform.Translate (Vector3.forward * Time.deltaTime * walkSpeed);


			}

		} else {


				walkSpeed = 0.4f;

				Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.green);
				//Track Player - Linear Interpolation (LERP)
				targetRotation = Quaternion.LookRotation (RallyPoint.transform.position - myTransform.position);
				//dog cannot rotate on its x axis (cannot look up)
				targetRotation.x = 0;
				adjRotSpeed = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
				myTransform.rotation = Quaternion.Lerp (myTransform.rotation, targetRotation, adjRotSpeed);
			
				transform.Translate (Vector3.forward * Time.deltaTime * walkSpeed);



		}
	}

	void adultBehaviour() {
		RaycastHit hit;
		if (Physics.Raycast (DogRaycast.transform.position, -(DogRaycast.transform.position - enemyPlayer.transform.position).normalized, out hit, AdultRange)) {
			
			//If hit has "Player" tag...
			if (hit.transform.tag == "Player") {


				//Track Player - Linear Interpolation (LERP)
				targetRotation = Quaternion.LookRotation (enemyPlayer.transform.position - myTransform.position);
				//dog cannot rotate on its x axis (cannot look up)
				targetRotation.x = 0;
				adjRotSpeed = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
				myTransform.rotation = Quaternion.Lerp (myTransform.rotation, targetRotation, adjRotSpeed);

				
				//Draw red debug line
				Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.red);

				/*
				 * //move towards character when close
					if (Physics.Raycast (DogRaycast.transform.position, -(DogRaycast.transform.position - enemyPlayer.transform.position).normalized, out hit, AdultAttackRange)) {
						transform.Translate (Vector3.forward * Time.deltaTime * walkSpeed);

				}
				*/

				} else {
				//Draw green debug line
				Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.green);
				transform.RotateAround (oldDog.transform.position, Vector3.up,  20 * Time.deltaTime);

				transform.LookAt( oldDog.transform.position );
				transform.Rotate( 0, -90, 0 );

			}

		} else {
			transform.RotateAround (oldDog.transform.position, Vector3.up,  20 * Time.deltaTime);

			transform.LookAt( oldDog.transform.position );
			transform.Rotate( 0, -90, 0 );
		}

	}

	void oldBehaviour() {
		RaycastHit hit;
		if (Physics.Raycast (DogRaycast.transform.position, -(DogRaycast.transform.position - enemyPlayer.transform.position).normalized, out hit, oldRange)) {
			
			//If hit has "Player" tag...
			if (hit.transform.tag == "Player") {
				
				//Track Player - Linear Interpolation (LERP)
				targetRotation = Quaternion.LookRotation (enemyPlayer.transform.position - myTransform.position);
				//dog cannot rotate on its x axis (cannot look up)
				targetRotation.x = 0;
				adjRotSpeed = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
				myTransform.rotation = Quaternion.Lerp (myTransform.rotation, targetRotation, adjRotSpeed);
			}
		}
	}
}
