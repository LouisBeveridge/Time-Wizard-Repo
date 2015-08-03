using UnityEngine;
using System.Collections;

public class MenuNewGame : MonoBehaviour {
	public Renderer rend;
	//Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		}
	void OnMouseEnter ()
		{
			rend.material.color = Color.grey;
		}
	void OnMouseExit ()
		{
			rend.material.color = Color.white;
		}
}
