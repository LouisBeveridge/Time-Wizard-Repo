using UnityEngine;
using System.Collections;

public class TargetLock : MonoBehaviour {

	public GameObject targetObj;
	private Transform target;
	private Transform myTransform;

	// Use this for initialization
	void Start () {

		myTransform = this.transform;
		target = targetObj.transform;

	}
	
	// Update is called once per frame
	void Update () {
		myTransform.LookAt(target);
	}
}
