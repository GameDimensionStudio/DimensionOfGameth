using UnityEngine;
using System.Collections;

public class WalkAreaMouseOver : MonoBehaviour {
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
			GameManager.ClickingObject = "WalkableArea";
		}
		
	}
}
