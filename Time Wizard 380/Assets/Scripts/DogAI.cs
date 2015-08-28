using UnityEngine;
using System.Collections;

public class DogAI : MonoBehaviour {

	//reference to the animation controller
	private Animator anim;
	//variable used to pass to animator controller
	//for mid dogs
	private bool seePlayer = false;
	private bool attacking = false;
	//for old dogs
	private bool sleeping = true;

	//health counters/vulnerability
	public int dogHealth = 10;
	private bool vulnerable = true;

	//attack box collider object
	public GameObject attackObject;
	BoxCollider attackCollider;

	//hit confirmation particles
	public GameObject attackHit;

	private Transform myTransform;
	public GameObject DogRaycast;

	//Case for what age of dog
	public int wolfStage;

	// old dog to orbit, and the targeter to keep them in a neat circle
	public GameObject oldDog;

	//young pup rally point, for when they cant see the player
	public GameObject RallyPoint;
	public bool Resting = false;

	//Aka, enemy in the view of the dog
	private GameObject enemyPlayer;
	
	//Range that dogs engage player at (young)
	private float range = 100000.0f;

	//adult
	public float AdultRange = 10.0f;
	public float AdultAttackRange = 8.0f;
	//old
	public float oldRange = 7.0f;

	//Dog speed
	public float walkSpeed = 2.0f;
	private float walkSpeedHolder;

	//Rotation Variables
	public float rotationSpeed = 3.0f;
	private float adjRotSpeed;
	private Quaternion targetRotation;
	public Transform center;

	private bool IsWalking = true;
	private bool IsAttacking = false;
	
	// Use this for initialization
	void Start () {



		//assign attack hitbox
		attackCollider = attackObject.GetComponent<BoxCollider> ();

		//populate the anim object
		anim = GetComponent<Animator> ();

		myTransform = this.transform;
		enemyPlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//wolf behaviour swtich
		switch(wolfStage){ 
		case 1: puppyBehaviour();
			anim.SetInteger("wolfStage",1);
			break;
		case 2: adultBehaviour();
			anim.SetInteger("wolfStage",2);
			break;
		case 3: oldBehaviour();
			anim.SetInteger("wolfStage",3);
			break;
		default: break;
		}//end switch
		

	}


/* PUPPY REST CODE (REDO)	
 * 
 * void OnTriggerStay (Collider col){
		if (col.gameObject.tag == ("RallyPoint")) {
			walkSpeed = 0.0f;
			print ("working");
			Resting = true;

}}
*/


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
	//--------------------------------------------------------------------------------------------------
	void adultBehaviour() {
		RaycastHit hit;
		if (Physics.Raycast (DogRaycast.transform.position, -(DogRaycast.transform.position - enemyPlayer.transform.position).normalized, out hit, AdultRange)) {
			
			//If hit has "Player" tag...
			if (hit.transform.tag == "Player") {

				anim.SetBool("seePlayer",true);

				//Track Player - Linear Interpolation (LERP)
				targetRotation = Quaternion.LookRotation (enemyPlayer.transform.position - myTransform.position);

				//dog cannot rotate on its x axis (cannot look up)
				targetRotation.x = 0;
				adjRotSpeed = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
				myTransform.rotation = Quaternion.Lerp (myTransform.rotation, targetRotation, adjRotSpeed);

				
				//Draw red debug line
				Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.red);


				 //move towards character when close
				if (Physics.Raycast (DogRaycast.transform.position, -(DogRaycast.transform.position - enemyPlayer.transform.position).normalized, out hit, AdultAttackRange) && (IsWalking == true)) {
					anim.SetBool("ApproachPlayer",true);
					transform.Translate (Vector3.forward * Time.deltaTime * walkSpeed);	
					//GetComponent<Animation> ().Play ("Walk");

						
				} else {

					//GetComponent<Animation>().Stop ("Walk");
					//GetComponent<Animation> ().Play ("SeePlayerIdle");
				}


				} else {
				//Draw green debug line
				Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.green);
				
				//MECHANIM UPDATE LINE
				anim.SetBool ("seePlayer", false);

				//GetComponent<Animation> ().Play ("Walk");
				Vector3 axis = Vector3.up;
				Vector3 desiredPosition;
				float radius = 5.0f;
				float radiusSpeed = 0.5f;
				float rotationSpeed = 15.0f;

				transform.RotateAround (oldDog.transform.position, Vector3.up,  rotationSpeed * Time.deltaTime);
				desiredPosition = (transform.position - center.position).normalized * radius + center.position;
				transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

				transform.LookAt( oldDog.transform.position );
				transform.Rotate( 0, -90, 0 );

			}

		} else {
			GetComponent<Animation> ().Play ("Walk");
			transform.RotateAround (oldDog.transform.position, Vector3.up,  20 * Time.deltaTime);

			transform.LookAt( oldDog.transform.position );
			transform.Rotate( 0, -90, 0 );


		}

	}
	//-----------------------------------------------------------------------------------------------------
	void oldBehaviour() {

		RaycastHit hit;
		if (Physics.Raycast (DogRaycast.transform.position, -(DogRaycast.transform.position - enemyPlayer.transform.position).normalized, out hit, oldRange)) {
			
			//If hit has "Player" tag...
			if (hit.transform.tag == "Player") {

				//MECANIM UPDATE LINE
				anim.SetBool("sleeping",false);

				Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.red);
				//Track Player - Linear Interpolation (LERP)
				targetRotation = Quaternion.LookRotation (enemyPlayer.transform.position - myTransform.position);
				//dog cannot rotate on its x axis (cannot look up)
				targetRotation.x = 0;
				adjRotSpeed = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
				myTransform.rotation = Quaternion.Lerp (myTransform.rotation, targetRotation, adjRotSpeed);
				//GetComponent<Animation> ().Stop ("SleepIdle");
				//GetComponent<Animation> ().Play ("SitIdle");
			
			}
		} else {
			Debug.DrawLine (DogRaycast.transform.position, hit.point, Color.green);

			//MECANIM UPDATE LINE
			anim.SetBool ("sleeping",true);

			//GetComponent<Animation> ().Play ("SleepIdle");
		}
	}

	//-----------------------------------------------------------------------------------------------

		void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Attack" && vulnerable) {



			vulnerable = false;

			Destroy(col.gameObject);
			GameObject flames = (GameObject)Instantiate(attackHit,this.gameObject.transform.position,Quaternion.identity);
			vulnerable = true;
			dogHealth = dogHealth-1;
		
		}//end if (tag==attack) 
	

		//if dog is not dead yet howl
		//if dog dies whimper
		if (dogHealth<1) { //is dead
			//whimper
			//play death animation
			//bust into particles
			Destroy(this.gameObject);
		} else { //is alive
			//bark
		}

	}//end on trigger enter 




	//-----------------------------------------------------------------------------------------------

	void AttackAnimation() {
		IsAttacking = true;
		print ("attack");
		anim.SetBool("attacking",true);

		attackCollider.enabled = false;
		StartCoroutine("canAttack");

		//GetComponent<Animation> ().Stop ("SeePlayerIdle");
		//GetComponent<Animation> ().Play ("AttackAnimation");
		IsAttacking = false;
	}

	void PrepareAttackAnimation() {
		walkSpeed = 0.0f;
		IsWalking = false;
		anim.SetBool("nearPlayer",true);
		if (IsAttacking == false) {
			//GetComponent<Animation> ().Stop ("Walk");
			//GetComponent<Animation> ().Play ("SeePlayerIdle");
		}
	}

	void ReturnToWalk(){
		walkSpeed = 2.0f;
		IsWalking = true;
		anim.SetBool("nearPlayer",false);
		//GetComponent<Animation> ().Play ("Walk");
	}




	IEnumerator canAttack() {
		//wait for five seconds.
		yield return new WaitForSeconds(1.5f);
		attackCollider.enabled = true;

	}//end IEnumerator


}
