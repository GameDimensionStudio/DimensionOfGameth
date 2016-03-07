using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInfo : MonoBehaviour {
	string DBtoSend = "";
	string DBtoRecieve ="";
	string[] sp;


	// Use this for initialization
	void Start () {
		char[] sharp = {'D','B'};
		DBtoSend = "@REQUEST_DB#1001#1002#1003#1004#1005#1006#1007#1008#1009#";
		DBtoSend = DBtoSend.Substring (DBtoSend.IndexOf("#"));
		print (DBtoSend);
		sp = DBtoSend.Split ('#');
		List<string> itemlsit = new List<string> (sp.Length);
		itemlsit.AddRange (sp);
		foreach (string item in itemlsit)
		{
			print (item);
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
