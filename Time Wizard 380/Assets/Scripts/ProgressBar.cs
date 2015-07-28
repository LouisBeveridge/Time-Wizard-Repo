using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Image image = GetComponent<Image>();

		image.fillAmount =Mathf.Lerp (image.fillAmount, 0f, Time.deltaTime *.5f);
	}
}
