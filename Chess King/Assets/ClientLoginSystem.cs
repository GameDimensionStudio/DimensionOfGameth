using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

class MessageBaseClient : MessageBase {
	public string networkmsg = "";
}

class ClientMsgTypes {
	public static short PLAYER_REQUEST_INFO = 1001;
	public static short SERVER_RESPONSE_INFO = 1002;
	public static short PLAYER_REQUEST_MM = 1003;
	public static short SERVER_RESPONE_MM = 1004;
	public static short CLIENT_KEEPALIVE = 1010;
};

public class ClientLoginSystem : MonoBehaviour {

	NetworkClient Client;

	private string userid = "";
	private string password = "";
	private string clientinformation = "";
	public InputField useripf;
	public InputField passwordipf;
	public Canvas Login;
	public Canvas UnsuccessfulLogin;
	public Canvas Exit;
	public Canvas Main;

	bool clientconnected = false;
	public Text mmrText;

	private string rcvmsg ="";
	public string globalmsg = "";

	public GameObject playerinfotempDB;
	public TempDB tempDB;

	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad (this);
		playerinfotempDB = GameObject.Find ("PlayerInfoTempDB");
		tempDB = playerinfotempDB.GetComponent<TempDB>();
	}

	void Start () {

		tempDB.userWIN = 5;
		mmrText.text = "My MMR = " + tempDB.userWIN;
		ConnectToLoginServer ();
	}

	// Update is called once per frame
	void Update () {
		//if (clientconnected == false) {
			Client.RegisterHandler (ClientMsgTypes.SERVER_RESPONSE_INFO, GetInfoFromLoginServer);
			Debug.Log ("Client is Active" + NetworkClient.active);
		//} else {
			//Reconnect ();
		//}

		//print (Client.connection.ToString());
	}
		

	public void ConnectToLoginServer(){
		string IpAddress = "127.0.0.1";
		int port = 49001;
		Client = new NetworkClient ();
		Client.Connect (IpAddress, port);
		Debug.Log ("Try to Conncet");

	}

	void ConnectToMasterServer(){
		string IpAddress = "127.0.0.1";
		int port = 49002;
		Client = new NetworkClient ();
		Client.Connect (IpAddress, port);

	}

	void Disconnect(){
		Client.Disconnect ();
	}
		
	public void VerifyUserPass(){
		if(userid != null && password != null)
		{
			userid = useripf.text.ToString ();
			password = passwordipf.text.ToString ();
			clientinformation = "@REQUEST_LOGIN#"+userid+"#"+password;
			print(clientinformation);
			SendInfoToLoginServer (clientinformation);
		}
	}

	void SendInfoToLoginServer(string info){
		var messageb = new MessageBaseClient ();
		messageb.networkmsg = info;
		Client.Send (ClientMsgTypes.PLAYER_REQUEST_INFO,messageb);
	}

	public void SendMatchMackingRequest(){
		string ID = "";
		string MMRequestMSG = "";
		ID = tempDB.userID.ToString ();
		MMRequestMSG = "@REQUEST_MM#" + ID;
		var messageb = new MessageBaseClient ();
		messageb.networkmsg = MMRequestMSG;
		Client.Send (ClientMsgTypes.PLAYER_REQUEST_MM,messageb);

	}

	void SendKeepAlive(){
		string keepalivemsg = "";
		var messageb = new MessageBaseClient ();
		messageb.networkmsg = keepalivemsg;
		Client.Send (ClientMsgTypes.PLAYER_REQUEST_INFO,messageb);
	}

	void GetInfoFromLoginServer (NetworkMessage netmsg){

		MessageBaseClient messageb = netmsg.ReadMessage<MessageBaseClient>();
		rcvmsg = messageb.networkmsg.ToString ();
		globalmsg = rcvmsg;
		Debug.Log ("Recieved Network Message" + rcvmsg);
		if (rcvmsg.StartsWith ("@REPLY_LOGIN")) {
			tempDB.FillUserInfo (rcvmsg);
			//Disconnect ();
			//ConnectToMasterServer ();
			Login.enabled = false;
			Main.enabled = true;
			print ("can't LOAD");
		}
		if(rcvmsg.StartsWith ("@REPLY_HEROINFO"))
			{
			tempDB.FillHero (rcvmsg);
			}
		if(rcvmsg.StartsWith ("@REPLY_HEROITEMINFO"))
		{
			tempDB.FillHeroItem (rcvmsg);
		}
		if (rcvmsg.StartsWith ("@UnsuccesslLogin")) {
			Login.enabled = false;
			UnsuccessfulLogin.enabled = true;
		}
		}
		

	void OnFailedToConnect(NetworkConnectionError error) {
		Debug.Log("Could not connect to server: " + error);
		globalmsg = "Could not connect to server: " + error;
	}

	public void OnConnected(NetworkConnection conn, NetworkReader reader) {
		Debug.Log("Connected to server");
		globalmsg = "Connected to server";
		clientconnected = true;
	}

	/*void OnLevelWasLoaded(int level) {
		if (level == 0) {
			ConnectToLoginServer ();
		}

	}*/


	//////// -----------------------------------------------------Function for Button Management----------------------------------------------------
	/// 
	/// 




	public void ConfirmUnsuccessfulLogin()
	{
		UnsuccessfulLogin.enabled = false;
		Login.enabled = true;
	}
	public void GameExit()
	{
		Login.enabled = false;
		Exit.enabled = true;
	}
	public void ConfirmExit()
	{
		Application.Quit ();
	}
	public void CancelExit()
	{
		Exit.enabled = false;
		Login.enabled = true;
	}
	IEnumerator Reconnect()
	{
		yield return new WaitForSeconds (5);
		Debug.Log ("Reconnecting...");
		ConnectToLoginServer ();
	}


	void OnGUI(){
		GUI.TextArea (new Rect(580,150,450,30),globalmsg);
	}


}
