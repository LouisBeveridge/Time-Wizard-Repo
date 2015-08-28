using UnityEngine;
using System.Collections;

public class HUDScriptShard : MonoBehaviour {
	public GameObject InnerShard;
	public GameObject Shards;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Shards.transform.Rotate (0,100 * Time.deltaTime, 0);
	}
}
