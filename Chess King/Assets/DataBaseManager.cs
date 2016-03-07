using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Player {
	public string PUserID  { get; set;}
	public string PUserLevel { get; set;}
	public string PUserMMR { get; set;}
	public string PUserEXP { get; set;}
	public string PUserWIN { get; set;}
	public string PUserLose { get; set;}
	public string PUserGold { get; set;}
	public string POnlineStatus { get; set;}

	public int PConnectionID  { get; set;}
	public bool PFindingMatchStatus { get; set;}
}

public class DataBaseManager : MonoBehaviour {

	static string ConstrGameDB = "";
	static string ConstrUserDB = "";
	private IDbConnection IDBcon;
	private IDbCommand IDBcmd;
	private IDataReader IDBReader;

	public static List<Player> playerlist;
	public List<Player> publicplayerlist;
	public int playerlistcount;
	public static int playercount;

	void Awake(){
		playerlist = new List<Player>();
		publicplayerlist = new List<Player> ();
	}

	int UserID;
	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR
		if (EditorApplication.isPlaying == true) {

			ConstrGameDB = "URI=file:" + Application.dataPath + "/Chess King Project/Resources/GameDB/GameDB.sqlite";
			ConstrUserDB = "URI=file:" + Application.dataPath + "/Chess King Project/Resources/GameDB/UserDB.sqlite";
		}
			
		#endif
		ConstrGameDB = "URI=file:" + "C:/Users/JayTanpol/Desktop/Chess King/Assets/Chess King Project/Resources/GameDB/GameDB.sqlite";
		ConstrUserDB = "URI=file:" + "C:/Users/JayTanpol/Desktop/Chess King/Assets/Chess King Project/Resources/GameDB/UserDB.sqlite";
	}
	
	// Update is called once per frame
	void Update () {
		playerlistcount = playerlist.Count;
		publicplayerlist = playerlist.ToList();
		if(publicplayerlist.Count != 0){
			Debug.Log ("Publiclist : "+publicplayerlist[0].PUserID);
		}

	}

	public string GetPlayerInfo (int ID,int ConID)
	{
		Player playerlistindex = null;
		string UserID = "";
		string UserLevel= "";
		string UserMMR= "";
		string UserEXP= "";
		string UserWIN= "";
		string UserLose= "";
		string UserGold= "";
		string OnlineStatus= "";


			string PlayerID = ID.ToString ();
			string Playerinfo = "";
			IDBcon = new SqliteConnection (ConstrUserDB);
			IDBcon.Open ();
			IDBcmd = IDBcon.CreateCommand ();
			IDBcmd.CommandText = "SELECT * FROM ALL_USER_DB WHERE USER_ID = '" + PlayerID + "'";
			IDBReader = IDBcmd.ExecuteReader ();

			while (IDBReader.Read ()) {
			
				UserID = IDBReader.GetInt32 (0).ToString ();
				UserLevel = IDBReader.GetInt32 (1).ToString ();
				UserMMR = IDBReader.GetInt32 (2).ToString ();
				UserEXP = IDBReader.GetInt32 (3).ToString ();
				UserWIN = IDBReader.GetInt32 (4).ToString ();
				UserLose = IDBReader.GetInt32 (5).ToString ();
				UserGold = IDBReader.GetInt32 (6).ToString ();
				OnlineStatus = IDBReader.GetString (7);
				Playerinfo = "@REPLY_LOGIN#" + UserID + "#" + UserLevel + "#" + UserMMR + "#" + UserEXP + "#" + UserWIN + "#" + UserLose + "#" + UserGold + "#" + OnlineStatus;

			}
		IDBReader.Close ();
		IDBReader = null;
		IDBcmd.Dispose ();
		IDBcmd = null;
		IDBcon.Close ();
		IDBcon = null;
		if (playerlist != null) {
			
			playerlistindex = playerlist.SingleOrDefault (p => p.PUserID == ID.ToString ());

			if (playerlist.Contains (playerlistindex) == false) {
				playerlist.Add (new Player {
					PUserID = UserID,
					PUserLevel = UserLevel,
					PUserMMR = UserMMR,
					PUserEXP = UserEXP,
					PUserWIN = UserWIN,
					PUserLose = UserLose,
					PUserGold = UserGold,
					POnlineStatus = "true",
					PConnectionID = ConID
				});
			}
		
		} else {
			playerlist.Add (new Player {
				PUserID = UserID,
				PUserLevel = UserLevel,
				PUserMMR = UserMMR,
				PUserEXP = UserEXP,
				PUserWIN = UserWIN,
				PUserLose = UserLose,
				PUserGold = UserGold,
				POnlineStatus = "true",
				PConnectionID = ConID
			});
		}
		Debug.Log ("Player Online After Add Player = " + playerlistcount);

		return Playerinfo;
	}
			

	public string GetHeroInfo (int ID)
	{
		string PlayerID = ID.ToString ();
		string Heroinfo = "";
		string UserHero = "";

		IDBcon = new SqliteConnection(ConstrUserDB);
		IDBcon.Open ();
		IDBcmd= IDBcon.CreateCommand();
		IDBcmd.CommandText = "SELECT * FROM USER_"+PlayerID+"_HERO_DB";
		IDBReader = IDBcmd.ExecuteReader();

		while(IDBReader.Read()){
			string UserHeroTemp;
			string UserHeroIDTemp;
			UserHeroTemp = IDBReader.GetString (1).ToString ();
			UserHeroIDTemp = IDBReader.GetInt32 (0).ToString ();
			UserHero = UserHero + "#" + UserHeroTemp +"|" + UserHeroIDTemp; 
		}
		Heroinfo = "@REPLY_HEROINFO" + UserHero;
		IDBReader.Close ();
		IDBReader = null;
		IDBcmd.Dispose ();
		IDBcmd = null;
		IDBcon.Close ();
		IDBcon = null;
		print (Heroinfo);
		return Heroinfo;
	}

	public string GetItemHeroInfo (int ID)
	{
		string PlayerID = ID.ToString ();
		string HeroIteminfo = "";
		string UserHeroItem = "";
		IDBcon = new SqliteConnection(ConstrUserDB);
		IDBcon.Open ();
		IDBcmd= IDBcon.CreateCommand();
		IDBcmd.CommandText = "SELECT * FROM USER_"+PlayerID+"_ITEM_DB WHERE ITEM_TYPE = 'HERO'";
		IDBReader = IDBcmd.ExecuteReader();

		while(IDBReader.Read()){
			string UserHeroItemTemp;
			UserHeroItemTemp = IDBReader.GetString (1).ToString ();
			UserHeroItem = UserHeroItem + "#" + UserHeroItemTemp; 
		}
		HeroIteminfo = "@REPLY_HEROITEMINFO" + UserHeroItem;
		IDBReader.Close ();
		IDBReader = null;
		IDBcmd.Dispose ();
		IDBcmd = null;
		IDBcon.Close ();
		IDBcon = null;
		return HeroIteminfo;
	}

	public string GetItemBoxInfo (int ID)
	{
		string PlayerID = ID.ToString ();
		string BoxIteminfo = "";
		string UserBoxItem = "";
		IDBcon = new SqliteConnection(ConstrUserDB);
		IDBcon.Open ();
		IDBcmd= IDBcon.CreateCommand();
		IDBcmd.CommandText = "SELECT * FROM USER_"+PlayerID+"_ITEM_DB WHERE ITEM_TYPE = 'BOX'";
		IDBReader = IDBcmd.ExecuteReader();

		while(IDBReader.Read()){
			string UserBoxItemTemp;
			UserBoxItemTemp = IDBReader.GetString (1).ToString ();
			UserBoxItem = UserBoxItem + "#" + UserBoxItemTemp; 
		}
		BoxIteminfo = "@REPLY_BOXITEMINFO" + UserBoxItem;
		IDBReader.Close ();
		IDBReader = null;
		IDBcmd.Dispose ();
		IDBcmd = null;
		IDBcon.Close ();
		IDBcon = null;
		return BoxIteminfo;
	}


	public int CheckUserPass(string user,string pass)
	{
		int ID;
		string userID = "";
		string Password = "";
		IDBcon = new SqliteConnection(ConstrGameDB);
		IDBcon.Open ();
		IDBcmd= IDBcon.CreateCommand();
		IDBcmd.CommandText="SELECT * FROM GAME_USER_DB WHERE USER_USER_ID = '"+user+"'";
		IDBReader = IDBcmd.ExecuteReader();

		while(IDBReader.Read()){
			ID =IDBReader.GetInt32(0);
			userID = IDBReader.GetString (1);
			Password = IDBReader.GetString (2);
			if (user == userID && pass == Password) {
				return ID;
			} else
				return 0;
		}
		IDBReader.Close ();
		IDBReader = null;
		IDBcmd.Dispose ();
		IDBcmd = null;
		IDBcon.Close ();
		IDBcon = null;
		return 0;
	}

	public void DelDisconnectPlayer(int conID)
	{
		Player playerlistindex = null;
		if (playerlist != null) {
			playerlistindex = playerlist.SingleOrDefault (p => p.PConnectionID == conID);
			playerlist.Remove (playerlistindex);
		}

	}


}
