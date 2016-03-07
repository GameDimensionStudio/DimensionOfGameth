using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Servermanager : NetworkManager {
	[SerializeField] GameObject PlayerPrefab;
	[SerializeField] GameObject GameBoard;
	bool ServerStarted = false;
	// Use this for initialization
	void Start () {
		//ConnectToMasterServer ();
		CreateInstaceServer(50001);
		NetworkServer.RegisterHandler (MsgType.AddPlayer, OnAddPlayer);
		NetworkServer.RegisterHandler (MsgType.Connect, OnConnected);
		NetworkServer.RegisterHandler (MsgType.Disconnect, OnDisConnected);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Time.deltaTime);
		if(NetworkServer.active && !ServerStarted){
			GameObject board = (GameObject)Instantiate(GameBoard,new Vector3(0,0,0),transform.rotation);
			NetworkServer.Spawn (board);
			ServerStarted = true;
			//NetworkServer.SpawnObjects ();
		}
	}

	void CreateInstaceServer(int port){
		NetworkServer.Listen (port);
		if (PlayerPrefab != null && GameBoard != null) {
			//ClientScene.RegisterPrefab (PlayerPrefab);
			//ClientScene.RegisterPrefab (GameBoard);
		}
	}

	/*void SpawnObject(){
		GameObject board = (GameObject)Instantiate(GameBoard,new Vector3(0,0,0),transform.rotation);
		GameObject player = (GameObject)Instantiate (PlayerPrefab, board.transform.position, transform.rotation);

		NetworkServer.Spawn (board);
		NetworkServer.Spawn (player);
	}*/

	void OnAddPlayer(NetworkMessage netMsg)
	{
		Debug.Log ("Add Player");

		GameObject player = (GameObject)Instantiate (PlayerPrefab, GameBoard.transform.position, transform.rotation);
		NetworkServer.AddPlayerForConnection(netMsg.conn, player, 0);
	}

	/*
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		base.OnServerAddPlayer (conn,playerControllerId);
		GameObject board = (GameObject)Instantiate(GameBoard,new Vector3(0,0,0),transform.rotation);
		GameObject player = (GameObject)Instantiate (PlayerPrefab, board.transform.position, transform.rotation);
		NetworkServer.Spawn (board);
		NetworkServer.AddPlayerForConnection(conn, player, 0);
		Debug.Log ("OnServerAddPlayer : " +conn.connectionId);
	}*/

	void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log ("Client connected : ConID = " + netMsg.conn.connectionId + " : " + NetworkServer.connections);
	
	}
	void OnDisConnected(NetworkMessage netMsg)
	{

		Debug.Log ("Client Disconnected : ConID = " + netMsg.conn.connectionId);
}
}