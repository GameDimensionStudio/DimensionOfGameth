using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	[SerializeField] GameObject player;

	
	
	//Variable for Mouse ClickedObject Event
	public static string WalkState = "STOP";
	public static string HeroControl = "";
	[SerializeField] public static string ClickingObject = "";
	[SerializeField] public static bool MouseIsDown = false;
	
	// Use this for initialization
	void Start () {
		Camera.main.transform.position = player.transform.position;
		player.gameObject.tag = "Enemy";

	}
	
	// Update is called once per frame
	void Update () {
	}



}
