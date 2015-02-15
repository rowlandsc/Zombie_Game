using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {
	public int health;
	public int moveSpeed;
	public int attack;


	private Transform target;
	private Transform player;
	private float range;
	/*
	 * This will all need to be changed to accomodate the static variable idea
	 */
	// Use this for initialization
	void Start () {
		target = null;
		this.player = GameObject.FindGameObjectWithTag ("player").transform;
		this.GetComponent<NavMeshAgent> ().enabled = false; // Don't find path till necessary
	}
	
	// Update is called once per frame
	void Update () {
		if (EventHandler.instance.getDroneCount () <= 10)
			moveTowardsPlayer ();
		else { 
			if(EventHandler.getFound() == true){
				moveTowardsPlayer();
				return;
			}
			// if the player is in the radious, then he or she is found
			if(player.position.x+10 > transform.position.x && player.position.x-10 < transform.position.x
			   && player.position.y+10 > transform.position.y && player.position.y -10 < transform.position.y
			   && player.position.z+10 > transform.position.z && player.position.z -10 < transform.position.z){
				//broadcast
				moveTowardsPlayer();
				return;
			}
			moveRandomDirection();
		}
	}

	public void moveTowardsPlayer(){
		moveTowards (player);
	}

	public void moveRandomDirection(){
		if (transform.position == target.position || target == null) {
			generateNewTarget();		
		}
		moveTowards (target);
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

	}
}
