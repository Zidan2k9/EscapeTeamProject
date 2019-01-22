using UnityEngine;
using System.Collections;

public class BasicEnemyscript : BasicEnemyCharacter {

	BaseCharacterScript basicEnemy;
	EnemyAI EAI = new EnemyAI();
	void Start () {
		basicEnemy = new BasicEnemyCharacter();
		EAI = this.gameObject.GetComponent<EnemyAI>();
	}
	void Update () {
	}
	public void basicAttack(){
		RaycastHit2D hit;
	}
	public void takeDamage(int damage){
		if(damage - Mitigation >= Health){
			// Gives the target(player) xp based on the enemys level.
			// Checks which of the characters hit it before giving that character xp
			if(EAI.target.name == "Tank(Clone)" || EAI.target.name == "Tank"){
				EAI.target.gameObject.GetComponent<TankScript>().recieveXP(giveXP());
				Destroy(this.gameObject);
			}
			else if(EAI.target.name == "Archer(Clone)" || EAI.target.name == "Archer"){
				EAI.target.gameObject.GetComponent<ArcherScript>().recieveXP(giveXP());
				Destroy(this.gameObject);
			}
		}
		else{
			Health = (Health - (damage - Mitigation));
		}
	}
	public int giveXP(){
		return Level * 50;
	}
	public void increaseLevel(int level){
		Level = level;
		Health = level * 10 + Health;
		Energy = level * 5 + Energy;
		Speed = level * 2 + Speed;
		Strength = level * 2 + Strength;
		Mitigation = level * 2 + Mitigation;
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "player"){
			if(col.gameObject.name == "Archer" || col.gameObject.name == "Archer(Clone)"){
				col.gameObject.GetComponent<ArcherScript>().takeDamage(Strength);
			}
			else if(col.gameObject.name == "Tank" || col.gameObject.name == "Tank(Clone)"){
				col.gameObject.GetComponent<TankScript>().takeDamage(Strength);
			}
		}
	}
}
