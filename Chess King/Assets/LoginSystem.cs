using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginSystem : MonoBehaviour {

	private string userid = "";
	private string password = "";
	public InputField useripf;
	public InputField passwordipf;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		userid = useripf.text.ToString ();
		password = passwordipf.text.ToString ();

	}

	void OnGUI()
	{
		//userid = GUI.TextField (new Rect(270,160,120,30),userid);
		//password = GUI.TextField (new Rect(270,200,120,30),password);
	}

	void ConncetToMasterServer(){
	
	}

	public void VerifyUserPass(string userid,string password){
		if(userid != null && password != null)
		{
			print("ID : "+userid +" Password : " + password);
		}
	}
}
