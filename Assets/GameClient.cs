using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

class MBCRequestLogin : MessageBase {
	public string networkmsg = "";
}

public class GameClient : MonoBehaviour {

	public NetworkClient Client;
	public string msg = "test";
	public bool connected = false;
	private string stringport = "";
	private int port = 0000;

	// Variable for Network Message
	private string text = "";
	private string sendtoservertext = "";
	private string stringconId = "0";

	private string rcvmsg ="";


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (NetworkClient.active == true) {
			Client.RegisterHandler (1000,ReadNetworkMessage);
		}

	}

	void OnGUI()
	{
		stringport = GUI.TextField (new Rect(140,10,50,30),stringport,5);
		if(GUI.RepeatButton (new Rect (20, 10, 100, 30),"Connect") && !connected)
		{
			msg = "Client is connected";
			connected = true;
			port = int.Parse (stringport);
			ConnectToServer (port);
		}
			
		if(GUI.RepeatButton (new Rect (20, 50, 100, 30),"Disconnect") && connected)
		{
			msg = "Client is Disconnected";
			connected = false;
			DisconnectToServer ();

		}

		if(GUI.RepeatButton (new Rect (20, 90, 100, 30),"Connection"))
		{
			msg = Client.connection.ToString();


		}
		GUI.TextArea (new Rect (200,10,150,30),msg);

		//////////////////////////////////////////Network Message//////////////////////////////////////////////

		sendtoservertext = GUI.TextField (new Rect(180,150,100,30),sendtoservertext,50);
		if(GUI.RepeatButton (new Rect (20, 150, 140, 30),"Send to Server"))
		{
			var messageb = new MessageBaseClient ();
			messageb.networkmsg = sendtoservertext;
			Client.Send (1000,messageb);
		}



		GUI.TextArea (new Rect(20,230,260,180),rcvmsg);


	}

	public void ReadNetworkMessage (NetworkMessage netmsg){

		MessageBaseClient messageb = netmsg.ReadMessage<MessageBaseClient>();
		rcvmsg = messageb.networkmsg.ToString ();
		Debug.Log ("Recieved Network Message" + rcvmsg);

	}



	public void ConnectToServer(int port) {
		string IpAddress = "127.0.0.1";
		Client = new NetworkClient ();
		Client.Connect (IpAddress, port);

	}



	public void DisconnectToServer() {
		Client.Disconnect ();
	}


}
