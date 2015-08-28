using UnityEngine;
using System.Collections;

public class DogAttackScript : MonoBehaviour {

	private bool CanAttack = true;
	private float attackRate = 1.0f;
	private float attackTime;
	public GameObject ThisDog;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > attackTime) {
				attackTime = Time.time + attackRate;
				CanAttack = true;
			}
		}

	void OnTriggerEnter(Collider collidingObject){
		if ((collidingObject.gameObject.tag == "Player")) {
			ThisDog.transform.SendMessage ("PrepareAttackAnimation", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerStay(Collider collidingObject){
		if ((collidingObject.gameObject.tag == "Player")) {
			if (CanAttack == true) {
				CanAttack = false;
				collidingObject.transform.SendMessage ("takeDamage", SendMessageOptions.DontRequireReceiver);
				ThisDog.transform.SendMessage ("AttackAnimation", SendMessageOptions.DontRequireReceiver);
				attackTime = Time.time + attackRate;
			}
		}
	}

	void OnTriggerExit(Collider collidingObject){
		if ((collidingObject.gameObject.tag == "Player")) {
			ThisDog.transform.SendMessage ("ReturnToWalk", SendMessageOptions.DontRequireReceiver);
		}
	}
}
