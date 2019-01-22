using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour {

	public GameObject enemy;
	GameObject clone;
	bool spawned = false;
	void Update(){
		if(spawned && clone == null){
			spawned = false;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(!spawned && col.gameObject.tag == "player"){
			clone = Instantiate(enemy, transform.position, transform.rotation) as GameObject;
			spawned = true;
		}
	}
}
