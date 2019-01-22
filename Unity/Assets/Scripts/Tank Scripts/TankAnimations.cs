using UnityEngine;
using System.Collections;

public class TankAnimations : MonoBehaviour {

	Animator tankAnimations;
	public GameObject camera;
	onScreenElementsScript OSES = new onScreenElementsScript();
	// Use this for initialization
	void Start () {
		OSES = camera.GetComponent<onScreenElementsScript> ();
		tankAnimations = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		//tankAnimations = GetComponent<Animator> ();
		Movement();
	}
	void Movement(){
		// MOVEMENT ANIMATIONS
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A)) {
			tankAnimations.SetBool ("tankWalking", true);
		}else{
			tankAnimations.SetBool ("tankWalking", false);
		}
		// JUMPING ANIMATION
		if (Input.GetKeyDown (KeyCode.Space)) {
			tankAnimations.SetBool ("tankJumping", true);
		}else{
			tankAnimations.SetBool ("tankJumping", false);
		}
		// BASIC ATTACK
		if (Input.GetKeyDown (KeyCode.J)) {
			tankAnimations.SetBool ("tankAttacking", true);
		} else {
			tankAnimations.SetBool("tankAttacking", false);
		}
	}
}
