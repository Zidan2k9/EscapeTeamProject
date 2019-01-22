using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

	public GameObject doorExit;
	public int level;
	
	void OnTriggerStay2D(Collider2D col){
		if(Input.GetKeyDown(KeyCode.W)){
			// Loads next level
			Application.LoadLevel(level);
		}
	}
}
