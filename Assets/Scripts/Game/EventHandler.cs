using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventHandler : MonoBehaviour{
	public static int multiplyNum;
	public static float spawnDelayTime;

	private static GameObject enemyMelee;
	private static GameObject enemyRanged;
	private static int wave;
	private static int timeBetweenWaves;
	private static int droneCount;
	private static GameObject[] spawnPoints;

	public static void init(){
		enemyMelee = Resources.Load("prefab/EnemyObject",typeof(GameObject)) as GameObject;
		enemyRanged = Resources.Load("prefab/EnemyObject",typeof(GameObject)) as GameObject;
		wave = 0;
		timeBetweenWaves = 30;
		droneCount = 0;
		spawnPoints = GameObject.FindGameObjectsWithTag ("spawner");
	}

	public static void getEventHandler(){
		EventHandler.droneCount--;
		if (EventHandler.droneCount == 0) { // start spawn wave sequence
			EventHandler.waitSpawn();
		}
	}

	private static IEnumerator waitSpawn(){
		yield return new WaitForSeconds (timeBetweenWaves);
		spawnWaves ();
		wave++;
	}

	public static GameObject getMelee(){
		return enemyMelee;
	}
	 
	public static IEnumerator  spawnWaves(){
		for (int i = 0; i < wave * multiplyNum; i++) {
			int index = Random.Range(0,spawnPoints.Length );
			if(Random.Range(-10,10) > 0)
			{ // Melee
				Instantiate(getMelee(), spawnPoints[index].transform.position, Quaternion.identity);
			} 
			else 
			{ // Ranged
				Instantiate(getMelee(),spawnPoints[index].transform.position, Quaternion.identity);
				Debug.Log("change Eventhandler.cs spawnwaves() for inclusion of ranged");
			}
			EventHandler.droneCount++;
			yield return new WaitForSeconds (spawnDelayTime);
		}
	}


}
//Time.smoothDeltaTime * 
//startCoRoutine
//instantiate