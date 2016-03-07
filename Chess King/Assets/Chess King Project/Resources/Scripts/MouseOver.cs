using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {
	
	public bool MouseIsOver = false;
	public bool MouseIsDown = false;
	public Vector3 GridCurrentPosition;

	public static Vector4 hexColor(float r, float g, float b, float a){
		Vector4 color = new Vector4(r/255, g/255, b/255, a/255);
		return color;
	}
	
	void OnMouseEnter(){
		MouseIsOver = true;
		GetComponent<Renderer> ().material.color = hexColor(255 ,8, 8, 140);
	}
	void OnMouseExit(){
			MouseIsOver = false;
		GetComponent<Renderer> ().material.color = hexColor(17,136,236,130);
}
	void OnMouseDown() {
		MouseIsDown = true;
		GridCurrentPosition = transform.position;
		print ("Now Mouse Clicking is Hero Destination : " + transform.position);
	}

}