using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	public bool paused;
	public GUISkin rpgSkin;
	private Rect pauseMenu;
	private int spikeCount;
	// Use this for initialization
	void Start () 
	{
		pauseMenu = new Rect(500,0,300,600);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
		{
			paused = true;
			Time.timeScale = 0.0f;
			Debug.Log("Game is paused");
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
		{
			paused = false;
			Time.timeScale = 1.0f;
			Debug.Log("Game is unpaused");
		}
	}

	void OnGUI()
	{
		if (paused == true) 
		{
			GUI.skin = rpgSkin;
			pauseMenu = GUI.Window (1, pauseMenu, showPauseMenu, "");
		}

	}

	void addSpikes(float winX)
	{
		spikeCount = (int)Mathf.Floor(winX - 152)/22;
		GUILayout.BeginHorizontal();
		GUILayout.Label ("", "SpikeLeft");
		for (int i = 0; i < spikeCount; i++)
		{
			GUILayout.Label ("", "SpikeMid");
		}
		GUILayout.Label ("", "SpikeRight");
		GUILayout.EndHorizontal();
		
	}

	void showPauseMenu(int windowID)
	{
		addSpikes(pauseMenu.width);
		
		GUILayout.BeginVertical();
		
		GUILayout.Label("Pause Menu");
		
		if(GUILayout.Button("Resume Game"))
		{
			paused = false;
			Time.timeScale = 1.0f;
		}
		if(GUILayout.Button("Stats"))
		{
			Application.LoadLevel("StatsScene");
		}
		if(GUILayout.Button("Options"))
		{
			Application.LoadLevel("OptionsScene");
		}
		if(GUILayout.Button("Quit to Main Menu"))
		{
			Application.LoadLevel("MainMenuScene");
		}
		if(GUILayout.Button("Quit to Desktop"))
		{
			Application.Quit();
		}
		
		GUILayout.EndVertical();
	}


}
