using UnityEngine;
using System.Collections;

public class ArcherAnimation : MonoBehaviour {

	Animator archerAnimations;
	public GameObject camera;
	onScreenElementsScript OSES = new onScreenElementsScript();
	// Variables for firing arrow
	public GameObject arrow;
	GameObject arrowClone;
	// Use this for initialization
	void Start () {
		OSES = camera.GetComponent<onScreenElementsScript> ();
		archerAnimations = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		archerAnimations = GetComponent<Animator> ();
		Movement();
	}
	void Movement(){
		// MOVEMENT ANIMATIONS
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A)) {
			archerAnimations.SetBool ("walking", true);
		}else{
			archerAnimations.SetBool ("walking", false);
		}
		// JUMPING ANIMATION
		if (Input.GetKeyDown (KeyCode.Space)) {
			archerAnimations.SetBool ("jumping", true);
		}else{
			archerAnimations.SetBool ("jumping", false);
		}
		// BASIC ATTACK
		if (Input.GetKeyDown (KeyCode.J)) {
			archerAnimations.SetBool ("firing", true);
			//FireArrowAnimation();
		} else {
			archerAnimations.SetBool("firing", false);
		}
		// DOT ATTACK
		if(Input.GetKeyDown (KeyCode.K) && OSES.getMagic()>=10){
			archerAnimations.SetBool ("DOTFiring", true);
		}else{
			archerAnimations.SetBool("DOTFiring", false);
		}
		// PIERCING SHOT
		if(Input.GetKeyDown (KeyCode.L) && OSES.getMagic()>=20){
			archerAnimations.SetBool ("PShotFiring", true);
		}else{
			archerAnimations.SetBool("PShotFiring", false);
		}
		// HOA SHOT
		if(Input.GetKeyDown (KeyCode.Semicolon) && OSES.getMagic()>=30){
			archerAnimations.SetBool ("HOAFiring", true);
		}else{
			archerAnimations.SetBool("HOAFiring", false);
		}
	}
	// FIRING ARROW ANIMATION -- Across screen
	void FireArrowAnimation(){
		arrowClone = Instantiate(arrow, transform.position, transform.rotation)as GameObject;
		Destroy (arrowClone, 2);
	}
}
