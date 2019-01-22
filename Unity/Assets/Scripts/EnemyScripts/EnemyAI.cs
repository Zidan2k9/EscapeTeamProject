using UnityEngine;
using Pathfinding;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public GameObject obs1,obs2;
	public float updateRate = 15f;
	Vector3 position;
	private Seeker seeker;
	private Rigidbody2D rb;

	public Path path;

	public float speed = 500f;
	float moveSpeed = 150;
	float rotation;
	bool pathIsEnded = false, moveRight, moveLeft, searchingForPlayer = false;
	float nextWaypointDistance = 3;
	private int currentWaypoint = 0;
	private Vector2 jumpDirection;
	Vector3 direction, curPos, lasPos;
	Quaternion rot;
	// For use with rotating the enemy in update method.
	int counter =0;


	// Use this for initialization
	void Start () {
		RaycastHit2D[] hit = fireRaycasts ();
		foreach (RaycastHit2D i in hit) {
			if (i.collider != null && i.collider.tag == "player") {
				target = i.collider.gameObject.transform;
			}
		}
		position = transform.position;

		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		if(target == null){
			if(!searchingForPlayer){
				searchingForPlayer = true;
				StartCoroutine(SearchForPlayer());
			}
			return;
		}

		seeker.StartPath(transform.position, target.position, OnPathComplete);

		StartCoroutine(UpdatePath());

		jumpDirection = Vector2.up;
	}
	void Update(){
		counter++;
		if(target != null){
			if(target.tag != "player" && counter >= 25){
				FlipEnemy();
				counter=0;
			}
		}
	}

	IEnumerator SearchForPlayer(){
		//TODO: Change searchResult to equal a method that fires raycasts either direction of the enemy.
		//GameObject searchResult = GameObject.FindGameObjectWithTag ("player");
		GameObject searchResult = detectPlayer().collider.gameObject;
		if (searchResult == null) {
			yield return new WaitForSeconds (0.5f);
			StartCoroutine (SearchForPlayer ());
		} else {
			target = searchResult.transform;
			searchingForPlayer = false;
			StartCoroutine(UpdatePath());
			return false;
		}
	}
	IEnumerator UpdatePath(){
		RaycastHit2D[] hit = fireRaycasts ();
		foreach (RaycastHit2D i in hit) {
			if (i.collider != null && i.collider.tag == "player") {
				target = i.collider.gameObject.transform;
				}
		}
		if(target == null){
			if(!searchingForPlayer){
				searchingForPlayer = true;
				StartCoroutine(SearchForPlayer());
			}
			return false;
		}
		if(target.tag == "player"){
			RotateEnemy ();
		}
		seeker.StartPath(transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds(2f/updateRate);
		StartCoroutine(UpdatePath());
	}
	public void OnPathComplete(Path p){
		if(!p.error){
			path = p;
			currentWaypoint = 0;
		}
	}
	// RAYCAST FIRING METHOD
	RaycastHit2D[] fireRaycasts(){
		position = transform.position;
		position.x += 1;
		RaycastHit2D[] hit = new RaycastHit2D[]{};
		if(rotation == 0.0f){
			hit = Physics2D.RaycastAll(transform.position, transform.right, 8f);
		}
		else if(rotation == 1.0f){
			hit = Physics2D.RaycastAll(transform.position, transform.right, 8f);
		}
		return hit;
	}
	RaycastHit2D fireRaycastDown(){
		position = transform.position;
		position.y -= 4f;
		RaycastHit2D hit = new RaycastHit2D ();
		return hit = Physics2D.Raycast (transform.position, -transform.up, 1f);
	}
	// SEARCHING FOR PLAYER
	RaycastHit2D detectPlayer(){
		RaycastHit2D hit = new RaycastHit2D();
		if(rotation == 0.0f){
			hit = Physics2D.Raycast(transform.position,transform.right, 5f);
		}
		else{
			hit = Physics2D.Raycast(transform.position,transform.right, 5f);
		}
		return hit;
	}
	// ENEMY ROTATION
	void RotateEnemy(){
		if(direction.x >= 0){
			rot.y = 0;
			transform.rotation = rot;
		}
		else if(direction.x <= 0){
			rot.y = 180;
			transform.rotation = rot;
		}
	}
	void FlipEnemy(){
		if(transform.rotation.y == 0){
			rot.y = 180;
			transform.rotation = rot;
		}
		else{
			rot.y = 0;
			transform.rotation = rot;
		}
	}
	// END OF ENEMY ROTATION
	void FixedUpdate(){
		// For making the enemy rotate to face the enemy
		/*rot = transform.rotation;
		Vector3 position = transform.position;
		if(target == null){
			RaycastHit2D[] hit = fireRaycasts ();
			foreach (RaycastHit2D i in hit) {
				if (i.collider != null && i.collider.tag == "player") {
					target = i.collider.gameObject.transform;
				}
			}
		}*/
		rotation = transform.rotation.y;
		
		if(target == null){
			if(!searchingForPlayer){
				searchingForPlayer = true;
				StartCoroutine(SearchForPlayer());
			}
			return;
		}
		//Debug.Log("Path: " + path);
		if(path == null){
			return;
		}
		if(currentWaypoint >= path.vectorPath.Count){
			if(pathIsEnded){
				return;
			}
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;

		direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		direction *= speed*5 * Time.fixedDeltaTime;
		rb.AddForce((direction), ForceMode2D.Force);
		float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
		if(distance < nextWaypointDistance){
			currentWaypoint++;
			return;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "ground"){
			jumpDirection *= speed/20 * Time.fixedDeltaTime;
			rb.AddForce((Vector2.up * speed/8), ForceMode2D.Force);
		}
	}
	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "ground"){
			jumpDirection *= speed/20 * Time.fixedDeltaTime;
			rb.AddForce((Vector2.up * speed/8), ForceMode2D.Force);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "player"){
			rb.AddForce((-direction * speed/20));
		}
	}
}
