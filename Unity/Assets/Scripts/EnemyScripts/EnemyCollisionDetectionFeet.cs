using UnityEngine;
using System.Collections;

public class EnemyCollisionDetectionFeet : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "ground") {
			this.transform.parent.rigidbody2D.gravityScale = 1f;
		} else {
			this.transform.parent.rigidbody2D.gravityScale = 10f;
		}
	}
	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "ground") {
			this.transform.parent.rigidbody2D.gravityScale = 1f;
		} else {
			this.transform.parent.rigidbody2D.gravityScale = 10f;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "ground"){
			this.transform.parent.rigidbody2D.gravityScale = 10f;
		}
	}
}
