using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
		Image LiveUI = GetComponent<Image>();
		
		LiveUI.fillAmount =Mathf.Lerp (LiveUI.fillAmount, 0f, Time.deltaTime *.5f);
	}
}