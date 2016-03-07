using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncMovement : NetworkBehaviour {

	[SyncVar]
	private Vector3 SyncPositon;

	[SerializeField] Transform ObjectTranform;
	[SerializeField] float LerpRate = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		OnLocalPosition ();
		OnServerPostion ();
	}

	void OnServerPostion() // Sync This Object on ther server
	{
		if (!isLocalPlayer) {
			ObjectTranform.position = Vector3.Lerp (ObjectTranform.position, SyncPositon, Time.deltaTime * LerpRate);
		}
	}

	[Command]
	void CmdSendPositon(Vector3 Position)
	{
		SyncPositon = Position;
	}

	[ClientCallback]
	void OnLocalPosition() // Call on LocalClient and invoke cmdfunction to sync the postion on server 
	{
		if (isLocalPlayer) {
			CmdSendPositon (ObjectTranform.position);
		}
	}
}
