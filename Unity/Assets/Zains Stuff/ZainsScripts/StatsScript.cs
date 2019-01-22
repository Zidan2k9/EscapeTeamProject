using UnityEngine;
using System.Collections;

public class StatsScript : MonoBehaviour 
{
	public GUISkin rpgSkin;
	private Rect statsBox;
	private int  spikeCount;
	GameObject player1;
	private float screenWidth;
	private float screenHeight;
	public static int archerKills = 0;
	public static int bruteKills = 0;
	public Texture backgroundImage;

	// Use this for initialization
	void Start () 
	{
		screenWidth = Screen.width / 2;
		screenHeight = Screen.height / 1.1f;
		statsBox = new Rect(250.0f,0,screenWidth,screenHeight);
		spikeCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundImage);

		GUI.skin = rpgSkin;
		if(GUI.Button(new Rect(650,70,200,50),"Go to MainMenu"))//Create buttons
		{
			Application.LoadLevel(0);
		}

		statsBox = GUI.Window (1, statsBox, showStatsBox, "");
		//now adjust to the group. (0,0) is the topleft corner of the group.
		GUI.BeginGroup (new Rect (0,0,100,100));
		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
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

	void showStatsBox(int windowID)
	{
		addSpikes(statsBox.width);
		
		GUILayout.BeginVertical();
		
		GUILayout.Label("Stats");
		
		GUILayout.Label ("Times Played :", "PlainText");
		
		GUILayout.Label ("", "Divider");

		GUILayout.Label ("Archer Kills :" +archerKills, "PlainText");
		GUILayout.Label ("Brute Kills :" + bruteKills, "PlainText");
		
		GUILayout.Label ("", "Divider");
		
		GUILayout.Label ("Currency collected :", "PlainText");
		
		GUILayout.Label ("", "Divider");
		
		GUILayout.Label ("Number of times killed :", "PlainText");
		
		GUILayout.Label("","Divider");
		
		GUILayout.Label("Items collected :","PlainText");
		GUILayout.Label("","PlainText");
		
		GUILayout.EndVertical();
	}
}
