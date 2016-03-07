using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;


class Client{
	int conID { get; set; }
	string ID { get; set; }
	string userID { get; set; }
	string password { get; set; }
}

class MessageBaseLoginServer : MessageBase {
	public string networkmsg = "";
}

public class LoginServerMsgTypes {
	public static short PLAYER_REQUEST_INFO = 1001;
	public static short SERVER_RESPONSE_INFO = 1002;
	public static short PLAYER_REQUEST_MM = 1003;
	public static short SERVER_RESPONE_MM = 1004;
	public static short INSTANCE_REQUEST_PORT = 1007;
	public static short SERVER_RESPONE_PORT = 1008;
	public static short CLIENT_KEEPALIVE = 1010;
	public static short SERVER_BROADCAST = 1011;
};

public class LoginServer : MonoBehaviour {

	private string rcvmsg = "";
	public  string globalmsg = "TEST";
	public static DataBaseManager DBManager;
	public GameObject MatchMakingManager;
	Matchmakingmanager MMManager;

	// Use this for initialization

	void Awake(){
		DBManager = gameObject.AddComponent<DataBaseManager>() as DataBaseManager;
		 MMManager = MatchMakingManager.GetComponent<Matchmakingmanager> ();
	}

	void Start () {
		StartServer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (NetworkServer.active == true) {
			NetworkServer.RegisterHandler (MsgType.Connect, OnConnected);
			NetworkServer.RegisterHandler (LoginServerMsgTypes.PLAYER_REQUEST_INFO, ReadNetworkMessage);
			NetworkServer.RegisterHandler (LoginServerMsgTypes.PLAYER_REQUEST_MM, ReadNetworkMessage);
			NetworkServer.RegisterHandler (MsgType.Disconnect, OnDisConnected);
		}
	}

	void StartServer() {
		int ServerPorts = 49001;
		NetworkServer.Listen (ServerPorts);
	}

	void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log ("Client connected : ConID = " + netMsg.conn.connectionId + " : " + NetworkServer.connections);
		globalmsg = "Client connected : ConID = " + netMsg.conn.connectionId + " : " + NetworkServer.connections;
	}
	void OnDisConnected(NetworkMessage netMsg)
	{
		DBManager.DelDisconnectPlayer (netMsg.conn.connectionId);
		MMManager.PlayerCancelFinding (netMsg.conn.connectionId);
		Debug.Log ("Client Disconnected : ConID = " + netMsg.conn.connectionId);
		globalmsg = "Client Disconnected : ConID = " + netMsg.conn.connectionId;
	}

	void ResponseInfo(int cID, string info){
		var messageb = new MessageBaseLoginServer ();
		messageb.networkmsg = info;

		NetworkServer.SendToClient (cID,LoginServerMsgTypes.SERVER_RESPONSE_INFO,messageb);
		globalmsg = "Send to Client : "+cID + info;
		Debug.Log (globalmsg);
	}

	void BroadcastInfo(string info){
		var messageb = new MessageBaseLoginServer ();
		messageb.networkmsg = info;
		NetworkServer.SendToAll (LoginServerMsgTypes.SERVER_BROADCAST,messageb);
	}

	public void ReadNetworkMessage (NetworkMessage netmsg){
		
		MessageBaseLoginServer messageb = netmsg.ReadMessage<MessageBaseLoginServer>();
		rcvmsg = messageb.networkmsg.ToString ();
		globalmsg =  messageb.networkmsg.ToString ();
		Debug.Log ("Recieved Network Message :" + rcvmsg);
		if (rcvmsg.StartsWith ("@REQUEST_LOGIN")) {
			RequestLogin (netmsg.conn.connectionId,rcvmsg);
		}
		if(rcvmsg.StartsWith("@REQUEST_MM")){
			rcvmsg = rcvmsg.Substring (rcvmsg.IndexOf ("#"));
			rcvmsg = rcvmsg.Substring (1);
			MMManager.MakeMatchFinderList (netmsg.conn.connectionId,rcvmsg);
		}
			
	}

	void RequestLogin(int conID ,string rcvmsg)
	{
		int ID;
		string user;
		string pass;
		string[] sp;
		string PlayerResponeInfo;
		string PlayerResponeHero;
		string PlayerResponeHeroItem;

		rcvmsg = rcvmsg.Substring (rcvmsg.IndexOf ("#"));
		Debug.Log ("After Substring : "+ rcvmsg);
		sp = rcvmsg.Split ('#');
		List<string> userpass = new List<string> (sp.Length);
		userpass.AddRange (sp);
		user = userpass [1];
		pass = userpass [2];

		Debug.Log (user +" "+pass);

		ID = DBManager.CheckUserPass (user, pass);
		if (ID != 0) {
			PlayerResponeInfo = DBManager.GetPlayerInfo (ID,conID);
			PlayerResponeHero = DBManager.GetHeroInfo (ID);
			PlayerResponeHeroItem = DBManager.GetItemHeroInfo (ID);
			ResponseInfo (conID, PlayerResponeInfo);
			ResponseInfo (conID, PlayerResponeHero);
			ResponseInfo (conID, PlayerResponeHeroItem);
		} else
			ResponseInfo (conID,"@UnsuccesslLogin");

	}

	void UpdateSyncPlayerInfo()
	{


	}
}



