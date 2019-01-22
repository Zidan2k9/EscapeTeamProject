using UnityEngine;
using System.Collections;

public class TankMovement : TankCharacterScript {

	TankScript tankScript = new TankScript();
	Quaternion rot;
	bool jump = false;
	bool jumping = false;
	// Use this for initialization
	void Start () {
		tankScript = GetComponent<TankScript>();
	}
	
	// Update is called once per frame
	void Update () {
		rot = transform.rotation;
		Movement();
	}
	
	void Movement(){
		// WALKING RIGHT
		if(Input.GetKey(KeyCode.D)){
			rot.y =0;
			transform.rotation = rot;
			rigidbody2D.AddForce(transform.right * Speed);
		}
		// WALKING LEFT
		if(Input.GetKey(KeyCode.A)){
			rot.y =180;
			transform.rotation = rot;
			rigidbody2D.AddForce(transform.right * Speed);
		}
		// JUMPING
		if(Input.GetKeyDown(KeyCode.Space)){
			if(jump == true){
				rigidbody2D.AddForce(transform.up * JumpSpeed);
				jump = false;
				jumping = true;
			}
			else{
				if(jumping == true){
					rigidbody2D.AddForce(transform.up * JumpSpeed);
					jumping = false;
				}
			}
		}
		// BASIC ATTACK
		if(Input.GetKeyDown(KeyCode.J)){
			tankScript.basicAttack();
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "ground"){
			jump = true;
		}
	}
}
