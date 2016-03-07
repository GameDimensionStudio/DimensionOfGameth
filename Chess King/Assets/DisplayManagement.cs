using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DisplayManagement : MonoBehaviour {
	GameObject Loginserver;
	LoginServer LS;
	public Text clientcounttext;
	public Text matchfidercounttext;
	public string output = "Test";
	public GameObject Databasemanager;
	DataBaseManager DBManager;
	public GameObject MatchMakingManager;
	Matchmakingmanager MMManager;

	public int findercount = 0;
	public int playercount = 0;
	// Use this for initialization
	void Awake(){
		Loginserver = GameObject.Find ("LoginServer");
		LS = Loginserver.GetComponent<LoginServer>();
		DBManager = Databasemanager.GetComponent<DataBaseManager> ();
		MMManager = MatchMakingManager.GetComponent<Matchmakingmanager> ();
	}

	void Start () {
		playercount = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if(LS != null){
			output = LS.globalmsg;
		}
			playercount = DBManager.playerlistcount;
		findercount = MMManager.matchfiderlistcount;
	}
	void OnGUI()
	{
		
		GUI.TextArea (new Rect(500,100,400,500),output);

		clientcounttext.text = "Player Online = " + playercount;
		matchfidercounttext.text = "Players are Finding Match = "+ findercount;


}
}
