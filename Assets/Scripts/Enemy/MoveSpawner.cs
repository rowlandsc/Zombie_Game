using UnityEngine;
using System.Collections;

public class MoveSpawner : MonoBehaviour {

	public GameObject spawnPoint_One;
	public GameObject spawnPoint_Two;
	public GameObject spawnPoint_Three;
	public GameObject spawnPoint_Four;
	public float fracJourney;

	private GameObject previousTarget;
	private GameObject target;

	void Start(){
		previousTarget = spawnPoint_Four; //this should probably be changed!!!!
		target = spawnPoint_One;
		move ();
	}

	void move(){
		transform.position = Vector3.Lerp(previousTarget.transform.position, target.transform.position, Time.deltaTime * fracJourney);
	}

	void Update () {
		// working on this part, the idea is to have it move 

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
			previousTarget = this.spawnPoint_One;
			target = this.spawnPoint_Two;		
		} else if(target == this.spawnPoint_Two){
			previousTarget = this.spawnPoint_Two;
			target = this.spawnPoint_Three;
		} else if(target == this.spawnPoint_Three){
			previousTarget = this.spawnPoint_Three;
			target = this.spawnPoint_Four;
		} else if(target == this.spawnPoint_Four){
			previousTarget = this.spawnPoint_Four;
			target = this.spawnPoint_One;
		} else{
			Debug.Log("Error: switchTarget was invalid. Auto-corrected to spawPoint_One.");
			previousTarget = this.spawnPoint_Four;
			target = this.spawnPoint_One;
		}
		move ();
	}
}
