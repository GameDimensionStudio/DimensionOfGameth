using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.Networking;

class MessageBaseServer : MessageBase {
	public string broadcastmsg = "";

}

public class GameMsgTypes {
	public static short MSG_LOGIN_RESPONSE = 1000;
	public static short MSG_SCORE = 1005;
};

public class GameServer : MonoBehaviour {
	public NetworkServer Server;
	public string msg = "test";
	public bool ServerStarted = false;
	bool Button = false;


	private string text = "";
	private string broadcasttext = "";
	private string stringconId = "0";
	private int conId = 0;
	private string rcvmsg ="";
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (NetworkServer.active == true) {
			NetworkServer.RegisterHandler (MsgType.Connect, OnConnected);
			NetworkServer.RegisterHandler (1000, ReadNetworkMessage);
			NetworkServer.RegisterHandler (MsgType.Disconnect, OnDisConnected);
		}
	}

	void OnGUI()
	{
		if(GUI.RepeatButton (new Rect (20, 10, 100, 30),"Start Server") && !ServerStarted)
		{
			ServerStarted = true;
			StartServer ();
			msg = "Server is started"+"\n";
		}
	


		if(GUI.RepeatButton (new Rect (20, 50, 100, 30),"Disconnect") && ServerStarted)
		{
			msg = "Server shutdow";
			ServerStarted = false;
			StopServer ();
		}

		if(GUI.RepeatButton (new Rect (20, 90, 100, 30),"Refresh"))
		{
			NetworkServer.ClearHandlers ();
			//Debug.Log (NetworkServer.connections);
			print (NetworkServer.connections.ToString() + " ");
		}

		GUI.TextArea (new Rect (150,10,100,30),msg);






		///////////////////////////////////////////////////// Send Message /////////////////////////////////////
		/// 
		/// 
		broadcasttext = GUI.TextField (new Rect(180,150,100,30),broadcasttext,50);
		if(GUI.RepeatButton (new Rect (20, 150, 140, 30),"Broadcast Message"))
		{
			var messageb = new MessageBaseServer ();
			messageb.broadcastmsg = broadcasttext;
			NetworkServer.SendToAll (1000, messageb);
		}
		if(GUI.RepeatButton (new Rect (20, 190, 140, 30),"Send to Client"))
		{

		}

		text = GUI.TextField (new Rect(180,190,100,30),text,50);
		stringconId = GUI.TextField (new Rect(300,190,30,30),stringconId,50);


		//Regex reg = new Regex ("0-9");
		Match match = Regex.Match(stringconId,"0-9");;
		if (stringconId != null && match.Success) {
			if (conId != int.Parse (stringconId)) {
				conId = int.Parse (stringconId);
			} else
				return;
		}

		GUI.TextArea (new Rect(20,230,260,180),rcvmsg);

	}


	///////////////////////////////////////////////////////// Function /////////////////////////////////////////////////////	


	public void StartServer() {
		int ServerPorts = 9999;
	
		NetworkServer.Listen (ServerPorts);
	}

	public void StopServer() {
		NetworkServer.Shutdown ();
	}

	void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log ("Client connected : ConID = " + netMsg.conn.connectionId + " : " + NetworkServer.connections);
	}
	void OnDisConnected(NetworkMessage netMsg)
	{
		Debug.Log ("Client Disconnected : ConID = " + netMsg.conn.connectionId);
	}

	public void ReadNetworkMessage (NetworkMessage netmsg){

		MessageBaseServer messageb = netmsg.ReadMessage<MessageBaseServer>();
		rcvmsg = messageb.broadcastmsg.ToString ();
		Debug.Log ("Recieved Network Message" + rcvmsg);
	}
}
