using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IconManagement : MonoBehaviour {

	public Button[] Hero = new Button[10];
	public Button[] ItemSlot = new Button[40];
	// Use this for initialization
	public GameObject playerinfotempDB;
	public TempDB tempDB;

	public Sprite hero1001;
	public Sprite hero1002;
	public Sprite hero1003;
	public Sprite hero1004;
	public Sprite hero1005;
	public Sprite hero1006;
	public Sprite hero1007;
	public Sprite hero1008;
	public Sprite hero1009;
	public Sprite hero1010;

	int counter = 0;
	int herocounter = 0;
	int itemcouter = 0;

	string output = "";
	void Awake()
	{
		playerinfotempDB = GameObject.Find ("PlayerInfoTempDB");
		tempDB = playerinfotempDB.GetComponent<TempDB>();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print (tempDB.HeroList.Count.ToString());
		if(tempDB.HeroList != null && tempDB.userONLINE == true)
		{
			for (int i = 0; i < tempDB.HeroList.Count; i++) {
				string heroid = tempDB.HeroList[i].ToString();
				Hero[i].image.sprite = Resources.Load<Sprite> ("Sprites/"+heroid);
				print ("Sprite ID = "+heroid);
			}
		}
	}
}
