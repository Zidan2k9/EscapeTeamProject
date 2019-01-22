using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	Transform playerPrefab;
	public Transform tankPrefab;
	public Transform archerPrefab;
	private GameObject tempPlayerPrefab;
	private Transform playerSpawn;
	public Transform spawnPoint;
	public Transform target;
	int distance;
	void Start (){
		playerPrefab = archerPrefab;
		SpawnCharacters ();
		if(spawnPoint == null){
			//TODO: Find closest spawn location
			return;
		}
	}
	// Update is called once per frame
	void Update () {
		if(target != null){
			transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -8.0f);
		}
		if (target == null) {
			target = playerSpawn;
		}
	}
	// This method spawns in charaters so the player can begin to control them.
	void SpawnCharacters(){
		playerSpawn = Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
		target = playerSpawn;
		if(playerPrefab == archerPrefab){
			setCharacterTank();
			Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		}
	}
	public void respawnPlayer(){
		//camera.GetComponent<switchCharcterScript> ().AddToPlayers (playerSpawn);
		playerSpawn = Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
		target = playerSpawn;
		camera.GetComponent<switchCharcterScript> ().AddToPlayers(playerSpawn.gameObject);
		camera.GetComponent<switchCharcterScript> ().FindPlayers ();
	}
	public void setSpawnPoint(Transform spawn){
		spawnPoint = spawn;
	}
	public void setCameraView(){
		target = GameObject.FindGameObjectWithTag ("player").transform;
	}
	public void setCharacterTank(){
		playerPrefab = tankPrefab;
	}
	public void setCharacterArcher(){
		playerPrefab = archerPrefab;
	}
	//TODO: method that changes the camera target
	public void changeTarget(Transform newTarget){
		target = newTarget;
	}
}
