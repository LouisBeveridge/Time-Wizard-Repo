using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour {

	public Canvas Menu;
	public Button NewGame;
	public Button Quit;
	public Button LevelSelect;

	// Use this for initialization
	void Start () {
		Quit = Quit.GetComponent <Button> ();
		NewGame = NewGame.GetComponent <Button> ();
		LevelSelect = LevelSelect.GetComponent <Button> ();
		Menu.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressQuit()
	{
		Application.Quit ();
	}

	public void StartGame ()
	{
		Menu.enabled = false;
		Application.LoadLevel (1);
	}
}
