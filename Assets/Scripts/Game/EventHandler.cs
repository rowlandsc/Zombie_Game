using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventHandler : MonoBehaviour {
	public GameObject GlobalVariablesObj;
	public GameObject enemeyMelee;
	public GameObject enemyRanged;
	public int multiplyNum;
	public float spawnDelayTime;

	private GameObject[] spawnPoints;
	private GlobalVariables globalVariables;
	
	void Start () {
		this.globalVariables = this.GlobalVariablesObj.GetComponent<GlobalVariables> ();
		this.spawnPoints = GameObject.FindGameObjectsWithTag ("spawner");
		this.globalVariables.wave++;
		StartCoroutine(this.spawnWaves ());
		this.spawnWaves ();
	}

	void Update () {
		
	}

	IEnumerator  spawnWaves(){

		for (int i = 0; i < this.globalVariables.wave * this.multiplyNum; i++) {
			int index = Random.Range(0,this.spawnPoints.Length );
			if(Random.Range(-10,10) > 0)
			{ // Melee
				Instantiate(this.enemeyMelee, this.spawnPoints[index].transform.position, Quaternion.identity);
			} 
			else 
			{ // Ranged
				Instantiate(this.enemeyMelee, this.spawnPoints[index].transform.position, Quaternion.identity);
				Debug.Log("change Eventhandler.cs spawnwaves() for inclusion of ranged");
			}
			this.globalVariables.zombieCount++;
			yield return new WaitForSeconds (Time.smoothDeltaTime * this.spawnDelayTime);
		}
	}
}
