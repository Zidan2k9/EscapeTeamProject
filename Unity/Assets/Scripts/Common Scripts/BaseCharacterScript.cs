using UnityEngine;
using System.Collections;

public class BaseCharacterScript : MonoBehaviour {
	private int health, energy, speed, jumpSpeed, strength, mitigation, level;

	// Default constructor
	public void CreateCharacter(){
		health = 100; energy = 100; speed = 50; jumpSpeed = 500; strength = 10; mitigation = 3; level = 1;
	}
	// Overridden constructor
	public void CreateCharacter(int health, int energy, int speed, int jumpspeed, int strength, int mitigation, int level){
		health = health; energy = energy; speed = speed; jumpSpeed = jumpspeed; strength = strength; mitigation = mitigation; level = level;
	}

	public int Health{
		get{return health;}
		set{health = value;}
	}
	public int Energy{
		get{return energy;}
		set{energy = value;}
	}
	public int Speed{
		get{return speed;}
		set{speed = value;}
	}
	public int JumpSpeed{
		get{return jumpSpeed;}
		set{jumpSpeed = value;}
	}
	public int Strength{
		get{return strength;}
		set{strength = value;}
	}
	public int Mitigation{
		get{return mitigation;}
		set{mitigation = value;}
	}
	public int Level{
		get{return level;}
		set{level = value;}
	}
}
