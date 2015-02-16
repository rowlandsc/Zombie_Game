using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour {

	public float timePassed = 0;
	public float timeTotal = 30f;

	public Text text;
	private bool ended = false;
	
	protected void Update() {
	
		timePassed += Time.deltaTime;
		
		if(text!=null) {
			
			text.text = ((int)(timeTotal - timePassed)).ToString();
		}
            
		if(timePassed>timeTotal && !ended) {
                
			ended = true;
		}
	}

	public void setTimeTotal(int time) {
		this.timeTotal = time;
	}
	
	public float getTimePassed() {
		return timePassed;
    }
}
