using UnityEngine;
using System.Collections;

public class TankCharacterScript : BaseCharacterScript{

	int abilityOneDamage = 0;
	int abilityTwoDamage = 0;
	int abilityThreeDamage = 0;

	public TankCharacterScript(){
		Health = 200; Energy = 100; Speed = 50; JumpSpeed = 700; Strength = 100; Mitigation = 15; Level = 1;
	}
	public void setAbilityOneDamage(){
		abilityOneDamage = Level * 4 + Strength;
	}
	public int getAbilityOneDamage(){
		return abilityOneDamage;
	}
	public void setabilityTwoDamage(){
		abilityTwoDamage = Level * 6 + Strength;
	}
	public int getAbilityTwoDamage(){
		return abilityTwoDamage;
	}
	public void setabilityThreeDamage(){
		abilityThreeDamage = Level * 10 + Strength;
	}
	public int getAbilityThreeDamage(){
		return abilityThreeDamage;
	}
}
