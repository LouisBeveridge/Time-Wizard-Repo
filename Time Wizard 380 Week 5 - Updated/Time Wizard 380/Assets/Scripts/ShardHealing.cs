using UnityEngine;
using System.Collections;

public class ShardHealing : MonoBehaviour {


	public GameObject GreenShard;
	public GameObject RedShard;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}


	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Player") {
			RedShard.SetActive(false);
			GreenShard.SetActive(true);
				}

	}//end on trigger


}
