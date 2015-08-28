using UnityEngine;
using System.Collections;

public class Shimmer : MonoBehaviour {


	public GameObject ShimmerParent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		doShimmer ();
	}

	void doShimmer(){

		if (Input.GetKey ("x")) {
			ShimmerParent.SetActive (true);
		} else {
			ShimmerParent.SetActive(false);
		}

	}//end do shimmer()

}
