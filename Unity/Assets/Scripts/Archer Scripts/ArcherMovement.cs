using UnityEngine;
using System.Collections;

public class ArcherMovement : ArcherCharacterScript {

	//ArcherCharacterScript archer = new ArcherCharacterScript();
	ArcherScript archerScript = new ArcherScript();
	Quaternion rot;
	bool jump = false;
	bool jumping = false;
	// Use this for initialization
	void Start () {
		archerScript = GetComponent<ArcherScript>();
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
		if(Input.GetKeyUp(KeyCode.J)){
			archerScript.basicShot();
		}
		// DOT ATTACK
		else if(Input.GetKeyUp(KeyCode.K)){
			archerScript.fireShot();
		}
		// PIERCING SHOT ATTACK
		else if(Input.GetKeyUp(KeyCode.L)){
			archerScript.piercingShot();
		}
		// HOA SHOT ATTACK
		else if(Input.GetKeyUp(KeyCode.Semicolon)){
			archerScript.hailOfArrows();
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "ground"){
			jump = true;
		}
	}
}
