using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class TempDB : MonoBehaviour {
	public string userID;
	public int userLEVEL;
	public int userMMR;
	public int userEXP;
	public int userWIN;
	public int userLOSE;
	public int userGOLD;
	public bool userONLINE;

	public string[] userHERO;
	public string[] userHeroITEM;
	public List<string> HeroList;
	public List<string> HeroItemList;

	// Use this for initialization
	void Start () {
		userHERO = new string[10];
		userHeroITEM = new string[40];
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void FillUserInfo(string info){
		print (info);
		info = info.Substring (info.IndexOf("#"));
		string[] sp;
		print (info);
		sp = info.Split ('#');
		List<string> infolist = new List<string> (sp.Length);
		infolist.AddRange (sp);
		userID = infolist [1];
		userLEVEL = Int32.Parse (infolist [2]);
		userMMR = Int32.Parse (infolist [3]);
		userEXP = Int32.Parse (infolist [4]);
		userWIN = Int32.Parse (infolist [5]);
		userLOSE =Int32.Parse (infolist [6]);
		userGOLD = Int32.Parse (infolist[7]);
		userONLINE = true;
		Debug.Log (userID+userLEVEL+userMMR+userEXP+userWIN+userLOSE+userGOLD+userONLINE);
	}
	public void FillHero(string info)
	{
		Debug.Log ("Fill Hero");
		info = info.Substring (info.IndexOf("#"));
		info = info.Substring (1);
		print (info);
		userHERO = info.Split ('#');
		HeroList.AddRange (userHERO);
	}
	public void FillHeroItem(string info)
	{
		Debug.Log ("Fill Hero Item");
		info = info.Substring (info.IndexOf("#"));
		info = info.Substring (1);
		print (info);
		userHeroITEM = info.Split ('#');
		HeroItemList.AddRange (userHeroITEM);
	}
}
