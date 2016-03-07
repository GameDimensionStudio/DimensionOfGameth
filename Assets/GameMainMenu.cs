using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameMainMenu : MonoBehaviour {

	public static string currentpage = "Main";

	public Canvas maincanvas;
	public Canvas teamedit;
	public Canvas itemwindow;
	public Button hero1;
	public Button hero2;
	public Button hero3;
	public Button hero4;
	public Button hero5;
	public Button hero6;
	public Button hero7;
	public Button hero8;
	public Button hero9;
	public Button hero10;
	public Button itemherowindow;
	public bool clickable = false;
	public Text mmrText;
	// Use this for initialization
	public GameObject playerinfotempDB;
	public TempDB tempDB;
	public GameObject clientlogin;
	public ClientLoginSystem CLS;
	public string currentObject = ""; 

	public Button findmatch;
	public Text findmatchtext;

	void Awake()
	{
		playerinfotempDB = GameObject.Find ("PlayerInfoTempDB");
		tempDB = playerinfotempDB.GetComponent<TempDB>();
		CLS = clientlogin.GetComponent<ClientLoginSystem> ();
	}


	void Start () {
		tempDB.userWIN = tempDB.userWIN+35;

	}
	
	// Update is called once per frame
	void Update () {
		mmrText.text = "MY MMR = " + tempDB.userWIN;
		if (itemherowindow.enabled == false) {
			DisableChild (itemherowindow);
		} else if(itemherowindow.enabled == true){
			EnableChild (itemherowindow);
		}
	}

	public void TeamEditMenu(){
		Debug.Log ("Now Clicking on : "+currentObject);
			maincanvas.enabled = false;
			teamedit.enabled = true;
		itemwindow.enabled = false;
		currentpage = "Team";
	}

	public void FindingMatch(){
		CLS.SendMatchMackingRequest ();
		findmatch.interactable = false;
		findmatchtext.text = "Finding Match...";
	}

	public void BackToMain(){
		Debug.Log ("Now Clicking on : "+currentObject);
		if (currentpage == "Team") {
			maincanvas.enabled = true;
			teamedit.enabled = false;
			itemwindow.enabled = false;
			currentpage = "Main";
		}
		else if(currentpage != "Team")
		{
			maincanvas.enabled = false;
			teamedit.enabled = true;
			itemwindow.enabled = false;
			currentpage = "Team";
		}
	}

	public void HeroSelectClick(){
		currentObject = EventSystem.current.currentSelectedGameObject.ToString();
		Debug.Log ("Now Clicking on : "+currentObject);
		itemwindow.enabled = true;
		Debug.Log ("Hero Click");
		currentpage = "ChooseHero";
	}

	public void BGClick(){
		currentObject = EventSystem.current.currentSelectedGameObject.ToString();
		Debug.Log ("Now Clicking on : "+currentObject);
		itemwindow.enabled = false;
		currentpage = "Team";
	}

	void Delay(){
		StartCoroutine (TimeDelay());
	}

	IEnumerator TimeDelay(){
		yield return new WaitForSeconds (2);
		clickable = true;
	}

	void DisableChild(Button gameobj){
		foreach (Transform child in gameobj.transform)
		{
			child.gameObject.SetActive (false);
		} 
	}
	void EnableChild(Button gameobj){
		foreach (Transform child in gameobj.transform)
		{
			child.gameObject.SetActive (true);
		} 
	}
}
