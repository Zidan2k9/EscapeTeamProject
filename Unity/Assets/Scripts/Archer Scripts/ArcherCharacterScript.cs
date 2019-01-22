using UnityEngine;
using System.Collections;

public class ArcherCharacterScript : BaseCharacterScript{

	int fireShotDamage = 0;
	int piercingDamage = 0;
	int hailOfArrowsDamage = 0;

	public ArcherCharacterScript(){
		Health = 100; Energy = 150; Speed = 100; JumpSpeed = 1000; Strength = 50; Mitigation = 3; Level = 1;
	}
	public void setFireShotDamage(){
		fireShotDamage = Level * 4 + Strength;
	}
	public int getFireShotDamage(){
		return fireShotDamage;
	}
	public void setPiercingDamage(){
		piercingDamage = Level* 5 + Strength;
	}
	public int getPiercingDamage(){
		return piercingDamage;
	}
	public void setHOADamage(){
		hailOfArrowsDamage = Level * 5 + Strength;
	}
	public int getHOADamage(){
		return hailOfArrowsDamage;
	}
}
