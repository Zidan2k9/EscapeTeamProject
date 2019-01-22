using UnityEngine;
using System.Collections;

public class TankScript : TankCharacterScript {
	
	BaseCharacterScript archer = new TankCharacterScript();
	CameraFollowScript camera = new CameraFollowScript ();
	onScreenElementsScript OSES = new onScreenElementsScript();
	GameObject player;
	float rotation;
	int baseXPMax, currentXP;
	Vector3 position;
	void Start(){
		camera = GameObject.FindGameObjectWithTag ("camera").GetComponent<CameraFollowScript>();
		OSES = camera.GetComponent<onScreenElementsScript>();
		//player = GameObject.FindGameObjectWithTag ("player");
		currentXP = 0; baseXPMax = 100;
		// SETTING TANKS DAMAGE ABILITIES
		setAbilityOneDamage ();
		setabilityTwoDamage ();
		setabilityThreeDamage ();
	}
	void Update(){
		rotation = this.gameObject.transform.rotation.y;
	}
	// ABILITY 1 ----- BASIC Attack
	public void basicAttack(){
		RaycastHit2D hit = fireRaycast(0.1f);
		if(hit.collider != null){
			if(hit.collider.tag == "Enemy"){
				hit.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(GetComponent<TankCharacterScript>().Strength);
			}
		}
	}
	// ABILITY 2 ----- FIRE PUNCH
	public void firePunch(){
		if(OSES.getMagic() >= 10){
			OSES.setMagic(OSES.getMagic() - 10);
			RaycastHit2D hit = fireRaycast(20);
			if(hit.collider != null){
				if(hit.collider.tag == "Enemy"){
					hit.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(getAbilityOneDamage());
				}
			}
		}
	}
	// ABILITY 3 ----- RAGE
	public void rageMode(){
		if(OSES.getMagic() >= 20){
			OSES.setMagic(OSES.getMagic() - 20);
			RaycastHit2D[] hit = fireMultipleRaycast(20);
			foreach(RaycastHit2D i in hit){
				if(i.collider.tag == "Enemy"){
					i.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(getAbilityTwoDamage());
				}
			}
		}
	}
	// ABILITY 4 ----- GROUND STOMP
	public void groundStomp(){
		if(OSES.getMagic() >= 30){
			OSES.setMagic(OSES.getMagic() - 30);
			RaycastHit2D[] hit = fireMultipleRaycast(20);
			foreach(RaycastHit2D i in hit){
				if(i.collider.tag == "Enemy"){
					i.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(getAbilityThreeDamage());
				}
			}
		}
	}
	// WHEN HIT RECIEVE DAMAGE
	public void takeDamage(int damage){
		if(damage - Mitigation >= Health){
			MovePlayerToSpawn();
			//Destroy(this.gameObject);
			// When kill reset onscreenelements values
			OSES.Reset();
			// Call the cameraFollowScript method that respawns the player
			//camera.respawnPlayer();
		}
		else{
			Health = (Health - (damage - Mitigation));
			// when taking damage update onscreenelements values
			OSES.setHealth(Health);
		}
	}
	// MOVE PLAYER BACK TO SPAWN POINT
	public void MovePlayerToSpawn(){
		transform.position = camera.spawnPoint.position;
	}
	// KILL PLAYER
	public void killPlayer(){
		MovePlayerToSpawn();
		OSES.Reset();
	}
	// METHOD TO FIRE RAYCAST
	public RaycastHit2D fireRaycast(float length){
		position = transform.position;
		RaycastHit2D hit = new RaycastHit2D();
		if(rotation == 0.0f){
			position.x += 0.5f;
			hit = Physics2D.Raycast(position, transform.right, length);
		}
		else if(rotation == 1.0f){
			position.x -= 0.5f;
			hit = Physics2D.Raycast(position, transform.right, length);
		}
		return hit;
	}
	// METHOD TO FIRE RAYCAST ALL
	public RaycastHit2D[] fireMultipleRaycast(float length){
		RaycastHit2D[] hit = new RaycastHit2D[]{};
		if(rotation == 0.0f){
			hit = Physics2D.RaycastAll(transform.position, transform.right, length);
		}
		else if(rotation == 1.0f){
			hit = Physics2D.RaycastAll(transform.position, transform.right, length);
		}
		return hit;
	}
	// METHOD TO RECIEVE XP
	public void recieveXP(int xp){
		currentXP = OSES.getXP();
		if((currentXP+xp) >= baseXPMax){
			increaseLevel(Level+1);
			baseXPMax = baseXPMax*2;
			OSES.setMaxXP(baseXPMax*2);
			currentXP += xp;
			OSES.setXP(currentXP);
		}
		else{
			currentXP += xp;
			OSES.setXP(currentXP);
		}
	}
	// INCREASES THE TANKS LEVEL
	public void increaseLevel(int level){
		if (Level != 5) {
			Level = level;
			// Increase health
			Health = level * 10 + OSES.getMaxHealth () / 2;
			// Setting new health variables
			OSES.setMaxHealth (Health * 2);
			OSES.setHealth (Health);
			// Increase magic/energy
			Energy = level * 5 + OSES.getMaxMagic () / 2;
			// Setting new magic/energy values
			OSES.setMaxMagic (Energy * 2);
			OSES.setMagic (Energy);
			Speed = level * 2 + Speed;
			Strength = level * 2 + Strength;
			Mitigation = level * 2 + Mitigation;
		}
	}
	// ENEMY COLLISION DETECTION
	void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Enemy"){
			Vector3 direction = (transform.position - col.rigidbody.transform.position).normalized;
			direction *= 500f;
			this.rigidbody2D.AddForce(direction);
		}
	}
	// SPAWN POINT LOCATION SETTING
	void OnTriggerEnter2D( Collider2D col){
		// COLLISION DETECTION ---- For spawn point
		if(col.collider2D.tag == "spawnPoint"){
			camera.setSpawnPoint(col.transform);
		}
		// COLLISION DETECTION ---- For key
		if(col.collider2D.tag == "key"){
			string keyName = "" + col.gameObject.name + "Door";
			GameObject door = GameObject.Find(keyName);
			door.GetComponent<doorAndKeyScript>().setKeyStatus(true);
		}
		// COLLISION DETECTION ---- For spikes
		if(col.collider2D.tag == "spikes"){
			this.killPlayer();
		}
	}
}
