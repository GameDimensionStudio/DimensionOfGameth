using UnityEngine;
using System.Collections;

public class BoardMouseOver : MonoBehaviour {
	public bool MouseIsOver = false;
	public bool MouseIsDown = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		MouseIsDown = true;
		if(GameManager.ClickingObject != null)
			GameManager.ClickingObject = "Board";
		print (HeroGamePlay.walkstatus);

	}
}
