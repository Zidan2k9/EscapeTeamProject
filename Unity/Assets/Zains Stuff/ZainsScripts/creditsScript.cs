using UnityEngine;
using System.Collections;

public class creditsScript : MonoBehaviour 
{
	public float speed;
	public bool rolling;
	public float position;
	GUIText creditsGUI;
	string credits;
	public Texture backgroundImage;

	// Use this for initialization
	void Start () 
	{
		speed = 0.2f;
		rolling = true;
		position = 2.59f;

		creditsGUI = this.gameObject.GetComponent<GUIText> ();


		credits =  "This game was made by LYIT Games Group 4 of the year 2015.\n";
		credits += "\n";
		credits += "Programmers\n";
		credits += "\n";
		credits += "Joseph Gillen\n";
		credits += "Zain Ul-Abdeen\n";
		credits += "\n";
		credits += "Game Design\n";
		credits += "\n";
		credits += "Mark Kelly\n";
		credits += "Brian Doherty\n";
		credits += "\n";
		credits += "Level Design\n";
		credits += "\n";
		credits += "Mark Kelly\n";
		credits += "Brian Doherty\n";
		credits += "\n";
		credits += "Artwork\n";
		credits += "\n";
		credits += "Joseph Gillen\n";
		credits += "\n";
		credits += "Sound Engineer\n";
		credits += "Brian Doherty\n";
		credits += "\n";
		credits += "GUI Design\n";
		credits += "\n";
		credits += "Zain Ul-Abdeen\n";
		credits += "With the help of Unity Asset Necromancer GUI\n";
		credits += "\n";
		credits += "Animations\n";
		credits += "\n";
		credits += "Joseph Gillen\n";
		credits += "\n";
		credits += "Game was developed in Unity 4.6.2\n";
		credits += "\n";
		credits += "©2015.\n";


		creditsGUI.text = credits;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!rolling)
		{
			return;
		}
		
		this.transform.Translate(Vector3.up * Time.deltaTime * speed);
		
		if(gameObject.transform.position.y > position)
		{
			rolling = false;
		}
		
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundImage);

		if(GUI.Button(new Rect(650,70,200,50),"Go to MainMenu"))//Create buttons
		{
			Application.LoadLevel(0);
		}
	}
}
