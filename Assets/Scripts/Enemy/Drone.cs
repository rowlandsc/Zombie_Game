using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {
	public int health;
	public int moveSpeed;
	public int attack;
	public int searchRange;
	public float attackRange;
	
	private GameObject target;
	private Transform player;
	/*
	 * This will all need to be changed to accomodate the static variable idea
	 */
	// Use this for initialization
	void Start () {
		searchRange = 20;
		target = new GameObject();
		generateNewTarget ();
		this.player = GameObject.FindGameObjectWithTag ("player").transform;
		this.GetComponent<NavMeshAgent> ().enabled = false; // Don't find path till necessary
	}
	
	// Update is called once per frame
	void Update () {
		if (EventHandler.Instance.getDroneCount () <= 10)
		{
			moveTowardsPlayer ();
			print("less than 10");
			return;
		}

		if(player.position.x+searchRange > transform.position.x && player.position.x - searchRange < transform.position.x
		   && player.position.y+searchRange > transform.position.y && player.position.y - searchRange < transform.position.y
		   && player.position.z+searchRange > transform.position.z && player.position.z - searchRange < transform.position.z){
			//broadcast
			EventHandler.Instance.setFound(true);
			moveTowardsPlayer();
			print("Move towards " + EventHandler.Instance.getFound());
			return;
		} else {
			if(EventHandler.Instance.getFound() == true){
				moveTowardsPlayer();
				EventHandler.Instance.setFound(false);
				return;
			}
			EventHandler.Instance.setFound(false);
		}

		print ("not found");
		//moveRandomDirection();

		//print("Move away: " + EventHandler.Instance.getFound());

		
	}

	public void moveTowardsPlayer(){
		moveTowards (player);
	}

	public void moveRandomDirection(){
		//if(target.transform.position.x == transform.position.x && target.transform.position.z == transform.position.z)
			generateNewTarget ();
		moveTowards (target.transform);
	}

	public void moveTowards(Transform movePlace){
		if(transform.position.y < 2){ // if component is still in the air, don't find a path
			this.GetComponent<NavMeshAgent>().enabled = true; // enable navmesh agent
			if (this.GetComponent<NavMeshAgent> ().pathStatus == NavMeshPathStatus.PathComplete) { // if a path has been found, move. if not do nothing.
				this.GetComponent<NavMeshAgent> ().SetDestination (movePlace.position);
			}
		}
	}

	public void generateNewTarget(){
		int walkRadius = 50;
		Vector3 randomDirection = Random.insideUnitSphere * walkRadius;// will need to be changed
		NavMeshHit hit;
		NavMesh.SamplePosition (randomDirection, out hit, walkRadius, 1);
		Vector3 finalPosition = hit.position;
		target.transform.position = finalPosition;
	}
}
