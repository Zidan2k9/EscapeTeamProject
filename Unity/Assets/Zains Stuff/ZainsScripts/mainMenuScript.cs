using UnityEngine;
using System.Collections;

public class mainMenuScript : MonoBehaviour 
{
	public GUISkin rpgSkin;
	public bool muteToggle;
	optionsScriptCSharp otherScript;
	public Texture backgroundImage;

	// Use this for initialization
	void Start () 
	{
		muteToggle = false;
		AudioListener.volume = 1.0f;
	}

	// Update is called once per frame
	void Update () 
	{
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundImage);

		GUI.skin = rpgSkin;


		if(GUI.Button(new Rect((Screen.width/2),70,150,50),"New Game"))//creating buttons, some do not work yet
		{
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect((Screen.width/2),110,150,50),"Stats"))
		{
			Application.LoadLevel(7);
		}
		if(GUI.Button(new Rect((Screen.width/2),150,150,50),"Options"))
		{
			Application.LoadLevel(6);
		}
		if(GUI.Button(new Rect((Screen.width/2),190,150,50),"Credits"))
		{
			Application.LoadLevel(5);
		}
		if(GUI.Button(new Rect((Screen.width/2),230,150,50),"Quit"))
		{
			Application.Quit();
		}
		if(muteToggle == false)//get the setting from the options menu
		{
			//otherScript.gameVolume();
		}
		else if(muteToggle == true)//does not work yet
		{
			AudioListener.volume = 0f;
		}
	}
}
