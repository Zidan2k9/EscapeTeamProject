using UnityEngine;
using System.Collections;

public class firingArrowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.AddForce(transform.right * 100);
	}
	void OnCollisionEnter2D(Collision2D col){
		Destroy(this.gameObject);
		if(col.gameObject.tag == "Enemy"){
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		Destroy(this.gameObject);
	}
}
