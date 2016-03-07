using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

public class client {
	public string id { get; set;}
	public string conid { get; set;}
	public bool online { get; set;}
}

public class TestCsharp : MonoBehaviour {
	List<client> stringlist;
	client rmclient;
	// Use this for initialization
	void Start () {

		runEXE ();
		/*
		stringlist = new List<client>();
		stringlist.Add (new client{id = "0",conid = "1",online = true});
		stringlist.Add (new client{id = "1",conid = "2",online = true});
		stringlist.Add (new client{id = "3",conid = "3",online = true});
		stringlist.Add (new client{id = "5",conid = "4",online = false});

		rmclient = stringlist.Single (o => o.id == "3");
		stringlist.Remove (rmclient);

		foreach (client allclient in stringlist)
		{
			Debug.Log ("ALL Client : "+ stringlist.Count+" ID : "+allclient.id+" Connection ID : "+allclient.conid+" Online Status : "+allclient.online);
		}*/



	}
	
	// Update is called once per frame
	void Update () {

	}

	void runEXE(){
		ProcessStartInfo startinfo = new ProcessStartInfo (@"C:\Users\JayTanpol\Desktop\Chess King\Build\InstanceServer.exe");
		//startinfo.Arguments = @"C:\Users\JayTanpol\Desktop\Chess King\Build\InstanceServer.exe";
		//startinfo.FileName = "dddddddddddddddd.exe";
		startinfo.CreateNoWindow = true;
		//startinfo.WindowStyle = ProcessWindowStyle.Hidden;
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);
		Process.Start (startinfo);

	}
}
