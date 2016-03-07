using UnityEngine;
using System.Collections;

public class CameraMoveZoom : MonoBehaviour {

	private Vector3 value ;
	private float MoveSpeed = 2000.0f;
	private float ZoomSpeedy = 10.0f;
	private float ZoomSpeedz = 600.0f;

	public bool MouseIsUp = false;
	public bool MouseIsPress = false;

	// Update is called once per frame
	void LateUpdate () {
		CameraMove ();

		}

	void CameraMove (){ 
		float InputAxisX = Input.GetAxis ("Mouse X");
		float InputAxisY = Input.GetAxis ("Mouse Y");

		if (Input.GetMouseButton (1)) {
			MouseIsPress = true;
			if (InputAxisX > 0) {

				value = transform.position += Vector3.left * InputAxisX * MoveSpeed * Time.deltaTime;
			}
			if (InputAxisX < 0) {
				value = transform.position -= Vector3.right * InputAxisX * MoveSpeed * Time.deltaTime;
			} 
			if (InputAxisY > 0) {
				value = transform.position += Vector3.back * InputAxisY * MoveSpeed * Time.deltaTime;
			}
			if (InputAxisY < 0) {
				value = transform.position -= Vector3.forward * InputAxisY * MoveSpeed * Time.deltaTime;
			} 
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, scroll * ZoomSpeedy, scroll * ZoomSpeedz, Space.Self);
	}

	}


