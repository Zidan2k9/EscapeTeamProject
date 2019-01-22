using UnityEngine;
using System.Collections;

public class doorAndKeyScript : MonoBehaviour {
	public GameObject key;
	bool isKeyPickedUp = false;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
	public bool getIsKeyPickedUp(){
		return isKeyPickedUp;
	}
	public void setKeyStatus(bool key){
		isKeyPickedUp = key;
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "player" && isKeyPickedUp){
			this.collider2D.isTrigger = true;
		}
	}
}
