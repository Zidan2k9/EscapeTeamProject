using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

//Author: Zain Ul-Abdeen
//Date created: 29/01/2015
//Date last edited: 19/02/2015
//Edited By Joseph Gillen: 23/04/2015

public class switchCharcterScript : MonoBehaviour 
{
	GameObject[] players;
	GameObject canvas;
	GameObject camera;
	Text playerText;

	GameObject archer, tank;

	// Use this for initialization
	void Start () 
	{
		camera = GameObject.FindGameObjectWithTag ("camera");
	}
	
	// Update is called once per frame
	void Update () 
	{	
		SelectingCharacter ();
		if(players == null){
			FindPlayers();
			// Call a method to set the archer as the first selected character.
			InitialSelect ();
		}
	}
	// This method allows you to change character based on keyboard presses.
	void SelectingCharacter(){
		if (players != null) {
			// Selecting the archer means that the scripts for tank get turned off.
			// This is made easy because of the list of players.
			if (Input.GetKey (KeyCode.Keypad1)) {
				foreach (GameObject go in players) {
					if (go.gameObject.name == "Archer(Clone)" || go.gameObject.name == "Archer") {
						go.gameObject.transform.position = players[1].transform.position;
						camera.GetComponent<CameraFollowScript>().changeTarget(go.transform);
						go.gameObject.GetComponent<ArcherMovement> ().enabled = true;
						go.gameObject.GetComponent<ArcherAnimation> ().enabled = true;
						go.gameObject.GetComponent<ArcherScript> ().enabled = true;
						go.gameObject.GetComponent<SpriteRenderer>().enabled = true;
						go.gameObject.rigidbody2D.gravityScale = 4;
						go.gameObject.collider2D.isTrigger = false;
						// This sets the respawnable character from camera follow script to be the currently selected character.
						camera.GetComponent<CameraFollowScript> ().setCharacterArcher ();
					} else if (go.gameObject.name == "Tank(Clone)" || go.gameObject.name == "Tank") {
						go.gameObject.GetComponent<TankMovement> ().enabled = false;
						go.gameObject.GetComponent<TankAnimations> ().enabled = false;
						go.gameObject.GetComponent<TankScript> ().enabled = false;
						go.gameObject.GetComponent<SpriteRenderer>().enabled = false;
						go.gameObject.rigidbody2D.gravityScale = 0;
						go.gameObject.collider2D.isTrigger = true;
					}
				}
				//playerText.text = "Archer selected";
				//playerText.color = Color.red;//change color
			}
			// Selecting the tank means that the scripts for archer get turned off.
			// This is made easy because of the list of players.
			if (Input.GetKey (KeyCode.Keypad2)) {
				foreach (GameObject go in players) {
					if (go.gameObject.name == "Tank(Clone)" || go.gameObject.name == "Tank") {
						go.gameObject.transform.position = players[0].transform.position;
						camera.GetComponent<CameraFollowScript>().changeTarget(go.transform);
						go.gameObject.GetComponent<TankMovement> ().enabled = true;
						go.gameObject.GetComponent<TankAnimations> ().enabled = true;
						go.gameObject.GetComponent<TankScript> ().enabled = true;
						go.gameObject.GetComponent<SpriteRenderer>().enabled = true;
						go.gameObject.rigidbody2D.gravityScale = 4;
						go.gameObject.collider2D.isTrigger = false;
						// This sets the respawnable character from camera follow script to be the currently selected character.
						camera.GetComponent<CameraFollowScript> ().setCharacterTank ();
					}
					if (go.gameObject.name == "Archer(Clone)" || go.gameObject.name == "Archer") {
						go.gameObject.GetComponent<ArcherMovement> ().enabled = false;
						go.gameObject.GetComponent<ArcherAnimation> ().enabled = false;
						go.gameObject.GetComponent<ArcherScript> ().enabled = false;
						go.gameObject.GetComponent<SpriteRenderer>().enabled = false;
						go.gameObject.rigidbody2D.gravityScale = 0;
						go.gameObject.collider2D.isTrigger = true;
					}
				}
				//playerText.text = "Tank selected";
				//playerText.color = Color.green;//change color
			}
		}
	}
	// This makes the character that you start playing with be the archer.
	void InitialSelect(){
		if (players != null) {
			foreach (GameObject go in players) {
				if (go.gameObject.name == "Archer(Clone)" || go.gameObject.name == "Archer") {
					go.gameObject.GetComponent<ArcherMovement> ().enabled = true;
					go.gameObject.GetComponent<ArcherAnimation> ().enabled = true;
					go.gameObject.GetComponent<ArcherScript> ().enabled = true;
					go.gameObject.GetComponent<SpriteRenderer>().enabled = true;
					go.gameObject.rigidbody2D.gravityScale = 4;
					go.gameObject.collider2D.isTrigger = false;
					// This sets the respawnable character from camera follow script to be the currently selected character.
					camera.GetComponent<CameraFollowScript> ().setCharacterArcher ();
				}
				if (go.gameObject.name == "Tank(Clone)" || go.gameObject.name == "Tank") {
					go.gameObject.GetComponent<TankMovement> ().enabled = false;
					go.gameObject.GetComponent<TankAnimations> ().enabled = false;
					go.gameObject.GetComponent<TankScript> ().enabled = false;
					go.gameObject.GetComponent<SpriteRenderer>().enabled = false;
					go.gameObject.rigidbody2D.gravityScale = 0;
					go.gameObject.collider2D.isTrigger = true;
				}
			}
		}
		//playerText.text = "Archer selected";
		//playerText.color = Color.red;//change color
	}
	public void FindPlayers(){
		// This finds all players
		players = GameObject.FindGameObjectsWithTag ("player");
	}
	// Adding a gameobject to the players arraylist
	public void AddToPlayers(GameObject go){
		players [players.Length] = go;
	}
	// Clearing the players array
	public void ClearPlayers(){
		Array.Clear (players, 0, players.Length);
	}
}
