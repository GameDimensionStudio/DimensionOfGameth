using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
//using System.Linq;

class MessageBaseTestServer : MessageBase {
	public string networkmsg = "";
}

class TestServerMsgTypes {
	public static short PLAYER_REQUEST_INFO = 1001;
	public static short SERVER_RESPONSE_INFO = 1002;
	public static short PLAYER_REQUEST_MM = 1003;
	public static short SERVER_RESPONE_MM = 1004;
	public static short INSTANCE_REQUEST_PORT = 1007;
	public static short SERVER_RESPONE_PORT = 1008;
	public static short INSTANCE_BROADCAST = 1013;
};

public class SVmananger : MonoBehaviour {

	NetworkClient Client;


	public GameObject PlayerPrefab;
	public GameObject GameBoard;

	// Use this for initialization
	void Start () {
		//ConnectToMasterServer ();
		CreateInstaceServer(50001);
	}

	// Update is called once per frame
	void Update () {
		/*if (Client != null) {
			if (Client.isConnected != false && Connected == false) {
				RequestPort ();
				Connected = true;
			}
			if (Client.isConnected == false && Connected == true) {
				Connected = false;
			}
			if (NetworkServer.connections.Count == 0 && DestroyCheck == false) {
				StartCoroutine (AutoDestroy());
			}
			if (Client.isConnected == true) {
				NetworkServer.RegisterHandler (InstanceMsgTypes.SERVER_RESPONE_PORT, ReadNetworkMessage);
			}
		}*/

	}


	void SpawnObject(){
		//GameObject board = (GameObject)Instantiate(GameBoard,new Vector3(0,0,0),transform.rotation);
		//GameObject player = (GameObject)Instantiate (PlayerPrefab, board.transform.position, transform.rotation);

		//NetworkServer.Spawn (board);
		//NetworkServer.Spawn (player);
	}

	void ConnectToMasterServer(){
		string IpAddress = "127.0.0.1";
		int port = 49001;
		Client = new NetworkClient ();
		Client.Connect (IpAddress, port);
	}

	void RequestPort(){
		string info = "@REQUEST_INSTANCE_PORT";
		var messageb = new MessageBaseClient ();
		messageb.networkmsg = info;
		Client.Send (InstanceMsgTypes.INSTANCE_REQUEST_PORT,messageb);
	}

	void CreateInstaceServer(int port){
		NetworkServer.Listen (port);
		if (PlayerPrefab != null && GameBoard != null) {
			ClientScene.RegisterPrefab (PlayerPrefab);
			ClientScene.RegisterPrefab (GameBoard);
		}
	}

	IEnumerator AutoDestroy(){
		
		int clientcount = 0;
		yield return new WaitForSeconds (600);
		if(NetworkServer.connections.Count == 0) {
			Application.Quit ();
			Debug.Log ("Application Close");
		}
	
	}

	void ReadNetworkMessage (NetworkMessage netmsg){
		string rcvmsg = "";
		int port;
		MessageBaseLoginServer messageb = netmsg.ReadMessage<MessageBaseLoginServer>();
		rcvmsg = messageb.networkmsg.ToString ();
		if (rcvmsg.StartsWith ("@RESPONE_INSTACE_PORT")) {
			rcvmsg = rcvmsg.Substring (rcvmsg.IndexOf ("#"));
			rcvmsg = rcvmsg.Substring (1);
			port = int.Parse (rcvmsg);
			CreateInstaceServer (port);
		}

	}
}
