using UnityEngine;
using System.Collections;

public class MoveSpawner : MonoBehaviour {

	public GameObject spawnPoint_One;
	public GameObject spawnPoint_Two;
	public GameObject spawnPoint_Three;
	public GameObject spawnPoint_Four;
	public GameObject target;

	public float fracJourney;
	

	/*
	 * This script will move spawners around the map utilizing the gameobjects above.
	 * You'll notice that all spawners will auto target spawnPoint_One by default. Near the end this should be changed, and I've left a debug.log() to indicate it.
	 * Note: unfortunately the prefab doesn't hold it so when we put these into the game permanently we'll have to add them ourselves individually. 
	 *       It isn't a lot of extra work, just kinda tedious.
     */

	void move(){
		transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime*fracJourney);
	}

	void Update () {
		// working on this part, the idea is to have it move 
		this.move ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "spawn_point") {
			switchTarget();		
		}
	} 

	void switchTarget(){
		// Function will switch target spawnPoint when the current target is reached
		// Switch statement is probably better here
		if (target == this.spawnPoint_One) {
			target = this.spawnPoint_Two;		
		} else if(target == this.spawnPoint_Two){
			target = this.spawnPoint_Three;
		} else if(target == this.spawnPoint_Three){
			target = this.spawnPoint_Four;
		} else if(target == this.spawnPoint_Four){
			target = this.spawnPoint_One;
		} else{
			Debug.Log("Error: switchTarget was invalid. Auto-corrected to spawPoint_One.");
			target = this.spawnPoint_One;
		}
	}
}
