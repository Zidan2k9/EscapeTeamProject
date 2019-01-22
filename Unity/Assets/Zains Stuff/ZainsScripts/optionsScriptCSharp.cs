using UnityEngine;
using System.Collections;

public class optionsScriptCSharp : MonoBehaviour 
{
	public GUISkin rpgSkin;
	//private int cont = 1;
	public bool muteToggle;
	public static float volumeSlider;
	public Texture backgroundImage;
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this.gameObject);
		//rpgSkin = new GUISkin[cont];
		muteToggle = false;
		volumeSlider = 0f;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundImage);

		GUI.skin = rpgSkin;

		if(GUI.Button(new Rect(650,70,200,50),"Go to MainMenu"))//Create buttons
		{
			Application.LoadLevel(0);
		}
		muteToggle = GUI.Toggle(new Rect(300,100,100,50),muteToggle,"Mute Music");

		if(muteToggle == false)
		{
			AudioListener.volume = volumeSlider;//assign volume to slider value
		}
		else if(muteToggle == true)
		{
			AudioListener.volume = 0f;
		}

		volumeSlider = GUI.HorizontalSlider(new Rect(400,350,100,30),volumeSlider,0.0f,1);
	}

	public static float gameVolume()//function used to transer volume setting to the mainMenuScript, later this will allow us to set the volume through out the game.
	{
		return volumeSlider;
	}

}
