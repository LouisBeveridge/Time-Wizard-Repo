using UnityEngine;
using System.Collections;

public class ShardHealing : MonoBehaviour {


	//--------Scar---------
	//GUI Objects
	public GameObject GuiScarCounter;
	Animator guiCounterAnim;
	//current healed scars
	public int scarsHealed = 0;


	public GameObject GreenShard;
	public GameObject RedShard;

	//checpoint teleport references (possibly change to vector 3's)
	public GameObject ShardOne, ShardTwo, ShardThree, ShardFour, ShardFive, ShardSix;

	void Awake() {
		guiCounterAnim = GuiScarCounter.GetComponent<Animator> ();
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//----------------------------START TRIGGERS----------------------------------


	void OnTriggerEnter(Collider col) {

		//Collsion with RED SCAR
		if (col.gameObject.tag == "PlayerRigid" && gameObject.tag=="RedScar") {

			//"lockout condition" dissallows the if statement to be triggered again for this scar
			gameObject.tag="GreenScar";

			//update the gui counter
			scarsHealed = guiCounterAnim.GetInteger("scarsHealed");
			scarsHealed = scarsHealed+1;
			guiCounterAnim.SetInteger("scarsHealed", scarsHealed);

			//change scar to be green
			RedShard.SetActive(false);
			GreenShard.SetActive(true);



				}//end redScar if

		if(col.gameObject.tag == "PlayerRigid" && gameObject.tag=="GreenScar") {

				}//end greenScar if

		//teleportation between shards

		//if col.gameObject.tag == "Player" &&
	

	}//end on trigger


	//----------------------------END TRIGGERS----------------------------------

}
