using UnityEngine;
using System.Collections;

public class AtkAreaMouseOver : MonoBehaviour {
	public bool MouseIsOver = false;
	public bool MouseIsDown = false;


	void Start () {


	}
	void Update()
	{

	}


	void OnMouseDown() {
		MouseIsDown = true;
		if (GameManager.ClickingObject != null) {
			GameManager.ClickingObject = "AtkableArea";
			HeroGamePlay.walkstatus = "YES";
		}

	}
}
