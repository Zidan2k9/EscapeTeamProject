using UnityEngine;
using System.Collections;

public class BasicEnemyCharacter : BaseCharacterScript {

	public BasicEnemyCharacter(){
		// health, energy, speed, jumpSpeed, strength, mitigation, level;
		Health = 100; Energy = 150; Speed = 50; JumpSpeed = 500; Strength = 50; Mitigation = 3; Level = 1;
	}  
}
