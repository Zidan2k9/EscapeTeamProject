 using UnityEngine;
using System.Collections;

public class DoorToDoor : MonoBehaviour {
	public GameObject doorEntrance;
	public GameObject doorExit;
	bool canTeleport = true;

	void OnTriggerStay2D(Collider2D col){
		if(Input.GetKeyDown(KeyCode.W)){
			col.gameObject.transform.position = doorExit.transform.position;
		}
	}
}
