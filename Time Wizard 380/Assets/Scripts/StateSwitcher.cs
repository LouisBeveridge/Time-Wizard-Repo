using UnityEngine;
using System.Collections;

public class StateSwitcher : MonoBehaviour {

	public GameObject New;
	public GameObject Mid;
	public GameObject Old;

	private Transform newTrans;
	private Transform midTrans;
	private Transform oldTrans;

	private int swapTo = 0;


	// Use this for initialization
	void Start () {
		newTrans = New.transform;
		midTrans = Mid.transform;
		oldTrans = Old.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//print (swapTo);
	
	}






	//public mutator
	public void setSwap(int set){
		swapTo = set;
		}

}
