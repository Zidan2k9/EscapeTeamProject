using UnityEngine;
using System.Collections;

public class ArcherScript : ArcherCharacterScript {

	BaseCharacterScript archer = new ArcherCharacterScript();
	CameraFollowScript camera = new CameraFollowScript ();
	onScreenElementsScript OSES = new onScreenElementsScript();
	GameObject player;

	float rotation;
	int baseXPMax, currentXP;
	Vector3 position;
	void Start(){
		camera = GameObject.FindGameObjectWithTag ("camera").GetComponent<CameraFollowScript>();
		OSES = camera.GetComponent<onScreenElementsScript>();

		// SETTING DAMAGE OF ARCHERS ABILITIES
		// METHODS TAKEN FROM ARCHER-CHARACTER-SCRIPT
		setFireShotDamage();
		setPiercingDamage();
		setHOADamage();
		//player = GameObject.Find("player");
		currentXP = 0; baseXPMax = 100;
	}
	void Update(){
		rotation = this.gameObject.transform.rotation.y;
	}
	// ABILITY 1 ----- BASIC SHOT
	public void basicShot(){
		RaycastHit2D hit = fireRaycast(10);
		if(hit.collider != null){
			if(hit.collider.tag == "Enemy"){
				hit.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(GetComponent<ArcherCharacterScript>().Strength);
			}
		}
	}
	// ABILITY 2 ----- FIRE SHOT
	public void fireShot(){
		if(OSES.getMagic() >= 10){
			OSES.setMagic(OSES.getMagic() - 10);
			RaycastHit2D hit = fireRaycast(20);
			if(hit.collider != null){
				if(hit.collider.tag == "Enemy"){
					hit.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(getFireShotDamage());
					damageOverTime(Level, hit);
				}
			}
		}
	}
	// ABILITY 3 ----- PIERCING SHOT
	public void piercingShot(){
		if(OSES.getMagic() >= 20){
			OSES.setMagic(OSES.getMagic() - 20);
			RaycastHit2D[] hit = fireMultipleRaycast(20);
			foreach(RaycastHit2D i in hit){
				if(i.collider.tag == "Enemy"){
					i.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(getPiercingDamage());
				}
			}
		}
	}
	// ABILITY 4 ----- HAIL OF ARROWS
	public void hailOfArrows(){
		if(OSES.getMagic() >= 30){
			OSES.setMagic(OSES.getMagic() - 30);
			RaycastHit2D[] hit = fireMultipleRaycast(20);
			foreach(RaycastHit2D i in hit){
				if(i.collider.tag == "Enemy"){
					i.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(getHOADamage());
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
	// DOT OF DAMAGE TO ENEMIES
	// When setting time 25 equals 1 second, so a standard 3 second DOT will be 75 for time.
	public void damageOverTime(int time, RaycastHit2D hit){
		int counter = 0;
		while(counter != time){
			if(hit.collider.tag == "Enemy"){
				hit.transform.gameObject.GetComponent<BasicEnemyscript>().takeDamage(GetComponent<ArcherCharacterScript>().Strength/4);
				counter++;
				if(counter > time){ break; }
			}
		}
	}
	// METHOD TO FIRE RAYCAST
	public RaycastHit2D fireRaycast(int length){
		position = transform.position;
		RaycastHit2D hit = new RaycastHit2D();
		if(rotation == 0.0f){
			position.x += 1;
			hit = Physics2D.Raycast(position, transform.right, length);
		}
		else if(rotation == 1.0f){
			//TODO: Fix this, it keeps hitting the archer.
			position.x -= 1;
			hit = Physics2D.Raycast(position, transform.right, length);
		}
		return hit;
	}
	// METHOD TO FIRE RAYCAST ALL
	public RaycastHit2D[] fireMultipleRaycast(int length){
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
	// INCREASES THE ARCHERS LEVEL
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
			setFireShotDamage ();
			setPiercingDamage ();
			setHOADamage ();
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
		// COLLISION DETECTION ---- For spawn points
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
