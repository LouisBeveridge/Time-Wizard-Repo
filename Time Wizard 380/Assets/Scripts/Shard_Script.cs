using UnityEngine;
using System.Collections;

public class Shard_Script: MonoBehaviour {

	//game object vars
	public GameObject InnerShard;
	public GameObject Shards;

	//scaling variables

	private float targetScaleZZZ;

	private Vector3 targetScale;
	public float maxScale = 1f;
	public float minScale = 1f;

	public float shrinkSpeed = 1.0f;

	private bool resizing = false;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		spin ();

		if (Input.GetMouseButtonDown(1))
			targetScale.Set(maxScale,maxScale,maxScale);
		if (Input.GetMouseButtonDown(0))
			targetScale.Set(minScale,minScale,minScale);
		if (Shards.transform.localScale != targetScale)
			Shards.transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime*shrinkSpeed);
	}

	//spin
	void spin() {

		Shards.transform.Rotate (0,100 * Time.deltaTime, 0);
	}



//-------------------------------------------------------------------------------------------------------



//-------------------------------------------------------------------------------------------------------



//-------------------------------------------------------------------------------------------------------

}
