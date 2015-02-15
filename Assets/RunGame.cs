using UnityEngine;
using System.Collections;

public class RunGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventHandler.init ();
		print ("here");
		StartCoroutine (EventHandler.spawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
