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
		if (this.spawnPoints == null) {
			this.spawnPoints = GameObject.FindGameObjectsWithTag ("spawner");
		}
		this.globalVariables.wave++;
		//StartCoroutine(this.spawnWaves ());
		this.spawnWaves ();
	}

	void Update () {
		
	}

	void spawnWaves(){

		for (int i = 0; i < this.globalVariables.wave * this.multiplyNum; i++) {
			int index = Random.Range(0,this.spawnPoints.Length -1);
			if(Random.Range(-10,10) > 0)
			{ // Melee
				foreach (GameObject spawn in this.spawnPoints) 
				{
					Instantiate(this.enemeyMelee, spawn.transform.position, spawn.transform.rotation);
					this.globalVariables.zombieCount++;
					//yield return new WaitForSeconds (Time.deltaTime* this.spawnDelayTime);
				}
			} 
			else 
			{ // Ranged
				foreach (GameObject spawn in this.spawnPoints) 
				{
					Instantiate(this.enemeyMelee, spawn.transform.position, spawn.transform.rotation);
					this.globalVariables.zombieCount++;
					//yield return new WaitForSeconds (Time.deltaTime * this.spawnDelayTime);
				}
			}
		}
	}
}
