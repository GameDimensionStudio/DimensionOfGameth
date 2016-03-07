using UnityEngine;
using System.Collections;

public class Turnmanager : MonoBehaviour {
	float timer = 5;
	int turncount = 0;
	string thisturn = "1";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TimeCount ();
	}

	void TimeCount()
	{
		if (timer >= 0) {
			timer -= Time.deltaTime;
			//Debug.Log ("Time : " + timer.ToString ("F1"));
			//Debug.Log ("Turncount : " + turncount + " / This Turn is : Player " + thisturn);
		} 
		else {
			timer = 5;
			turncount++;
			TakeTurn ();
		}
			
	}

	void TakeTurn(){
		if (thisturn == "1") {
			thisturn = "2";
			return;
		}
		if (thisturn == "2") {
			thisturn = "1";
			return;
		}
	}
}
