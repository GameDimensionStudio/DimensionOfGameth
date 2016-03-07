using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Clientmanager : NetworkManager {
	NetworkClient Client;
	NetworkConnection conn;
	bool Connected = false;
	[SerializeField] GameObject PlayerPrefab;
	[SerializeField] GameObject GameBoard;
	// Use this for initialization
	void Start () {
		ConnectToMasterServer ();
	}
	
	// Update is called once per frame
	void Update () {
		Client.RegisterHandler (MsgType.Connect, OnConnected);

		Debug.Log (Client.isConnected);
		if (Client.isConnected && !Connected) {
			if(!ClientScene.ready){
				ClientScene.Ready (Client.connection);
				ClientScene.RegisterPrefab (PlayerPrefab);
				ClientScene.RegisterPrefab (GameBoard);
				ClientScene.AddPlayer (0);

			Debug.Log (ClientScene.ready);
				CameraPostion ();
				Connected = true;
			}
	
		}

	}

	public void ConnectToMasterServer(){
		string IpAddress = "127.0.0.1";
		int port = 50001;
		Client = new NetworkClient ();
		Client.Connect (IpAddress, port);
	}
	void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log ("Client connected : ConID = " + netMsg.conn.connectionId + " : " + NetworkServer.connections);




	}
	void OnDisConnected(NetworkMessage netMsg)
	{

		Debug.Log ("Client Disconnected : ConID = " + netMsg.conn.connectionId);
		Connected = false;
}

	public override void OnClientConnect(NetworkConnection conn)
	{
		Debug.Log ("Connected");

	}

	void CameraPostion(){
		Camera.main.transform.position = PlayerPrefab.transform.position;
	}

}

