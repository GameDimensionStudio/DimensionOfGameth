using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Matchmakingmanager : MonoBehaviour {

	public GameObject Databasemanager;
	DataBaseManager DBManager;
	public static List<Player> matchfinderlist;
	public int matchfiderlistcount;

	void Awake(){
		DBManager = Databasemanager.GetComponent<DataBaseManager> ();
		matchfinderlist = new List<Player>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		matchfiderlistcount = matchfinderlist.Count;
		if (matchfinderlist.Count >= 2) {
			MatchMaking ();
		}
	}

	public void MakeMatchFinderList(int conID,string finderID){
		Player matchfinderindex = null;
		Debug.Log ("MatchFinderID = " + finderID);
		if (DBManager.publicplayerlist != null) {
			matchfinderindex = DBManager.publicplayerlist.SingleOrDefault (p => p.PUserID == finderID && p.PConnectionID == conID);
			Debug.Log ("Incomming ID : " + finderID + "Incoming ConID : "+ conID);
			Debug.Log ("ID : " + DBManager.publicplayerlist[0].PUserID+"ConID : "+ DBManager.publicplayerlist[0].PConnectionID);
			Debug.Log ("ID : " + matchfinderindex.PUserID+"ConID : "+ matchfinderindex.PConnectionID);
			matchfinderlist.Add (matchfinderindex);
			Debug.Log("Matchfinderlist = "+ matchfinderlist.Count);
		}

	}
	void MatchMaking(){
		Debug.Log ("Now Match is Already found");
	}
	public void PlayerCancelFinding (int conID){
		Player matchfinderindex = null;
		if (matchfinderlist != null) {
			matchfinderindex = matchfinderlist.SingleOrDefault (p => p.PConnectionID == conID);
			matchfinderlist.Remove (matchfinderindex);
		}
	}
}
