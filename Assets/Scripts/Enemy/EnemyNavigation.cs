using UnityEngine;
using System.Collections;

public class EnemyNavigation : MonoBehaviour {
	private Transform target;

	// Use this for initialization
	void Start () {
		this.target = GameObject.FindGameObjectWithTag ("player").transform;
		this.GetComponent<NavMeshAgent> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < 2){
			this.GetComponent<NavMeshAgent>().enabled = true;
			if (this.GetComponent<NavMeshAgent> ().pathStatus == NavMeshPathStatus.PathComplete) {
				this.GetComponent<NavMeshAgent> ().SetDestination (target.position);
			}
		}
	}
}
