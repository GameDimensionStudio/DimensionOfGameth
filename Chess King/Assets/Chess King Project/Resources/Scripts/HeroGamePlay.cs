using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HeroGamePlay : NetworkBehaviour {
	//Variable for connect to Gamemanager




	
	//Variable for position at Startpoint
	public float startpointX = 0;
	public float startpointy = 50;
	public float startpointZ = 100;

	//Variable for Hero Character's Info
	//public static string name;
	//public static string heroclass;
	public static int mov = 1;



	//Variable for CreatePathway
	public bool MouseIsDown = false;
	public static GameObject wa = null;
	public static Vector3[] WalkableGrid;


	//Variable for Hero Walk to Destination
	public static Vector3 HeroCurrentPos;
	public static Vector3 HeroDestination;
	public Vector3 newPosition;
	public Vector3 targetPosition;
	[SerializeField] public static string walkstatus = "No"; // YES = Allow to walk // No = Not allow to walk // Walking = it's walking
	[SerializeField] public static string walkstate = "Stop";
	public static Vector3 CheckWalkFinish;
	public static float startspeed = 0.01f;
	float walkspeed = 0.015f;
	[SerializeField] bool startwalking = false;

	// Assign all start value for Hero
	void Start () {
		HeroCurrentPos = transform.position = new Vector3 (startpointX, startpointy, startpointZ);
	}

	/// Mouse Clink on Hero Event /// 
	void OnMouseDown(){
		if (!isLocalPlayer) {
			return;
		}
		MouseIsDown = true;
		CharacterControl ();
	}

	/// Deley timing Before Hero going to walk 
	IEnumerator Delay (){
		yield return new WaitForSeconds (0.2f);
		walkstate = "Ready";
		walkstatus = "YES";
		print ("After 2 second");
	}
		
	// Update is called once per frame

	void CharacterControl()
	{
		if (!isLocalPlayer) {
			return;
		}
		GameObject gmObject = GameObject.Find("GameManager");
		GameManager gm = (GameManager) gmObject.GetComponent(typeof(GameManager));
		if (GameManager.ClickingObject != "Hero" && walkstate == "Stop") {
			CreatePathway (transform.position);
			GameManager.ClickingObject = "Hero";
			StartCoroutine (Delay ());

		}
		print (HeroCurrentPos);
	}

	void Update () {
		if (!isLocalPlayer) {
			return;
		}

		if (walkstatus != "Walking" && GameManager.ClickingObject != "Hero") {
			PathWayDestroy ();
		}

		ClickToWalk ();
			
	
	}

	void FixedUpdate(){
		if (!isLocalPlayer) {
			return;
		}
		if (walkstate == "Walking" && walkstatus != "NO") {
			//print ("Mouse Position Value = " + targetPosition + "Hero Origin Postion =" + transform.position);
			Walk (targetPosition);
			print (walkstatus);
		}
	}

	void ClickToWalk(){
		if (!isLocalPlayer) {
			return;
		}
		if (Input.GetMouseButtonDown (0) && HeroGamePlay.walkstatus == "YES" && walkstate == "Ready") {

			print (walkstatus);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit) && hit.transform.tag == "WalkArea") {
				targetPosition = hit.point;
				//WalkRangeX = Mathf.Abs (targetPosition.x - transform.position.x);
				walkstate = "Walking";
			} else {
				walkstatus = "NO";
				walkstate = "Stop";
			}
		}
	}

	void Walk(Vector3 Destination){
		if (!isLocalPlayer) {
			return;
		}
		if (startwalking == false) {
			HeroCurrentPos = transform.position;
		}
		if (Destination != HeroCurrentPos) {
			transform.position = Vector3.Lerp (HeroCurrentPos,Destination,startspeed);
			transform.position= new Vector3(transform.position.x,50,transform.position.z);
			startspeed = walkspeed+startspeed;
			startwalking = true;
			print ("T : " + HeroCurrentPos + startwalking+ " / walkspeed = " + walkspeed);
		}
		
		CheckWalkFinish = Destination - transform.position;
		if(CheckWalkFinish.sqrMagnitude <= new Vector3(38,0,38).sqrMagnitude) {
			print ("Walk Finish : " + walkspeed + "walkstart = " + startspeed);
			walkstate = "Stop";
			startwalking = false;
			startspeed = 0.01f;
	}
	}

	public void CreatePathway(Vector3 currentPosition){
		print ("this is ClinkedObject value " + GameManager.ClickingObject);
		if (GameManager.ClickingObject != "Hero") {
			wa = Instantiate (Resources.Load ("Prefabs/WalkArea"), new Vector3 (currentPosition.x, currentPosition.y-35, currentPosition.z), Quaternion.Euler (0, 0, 0)) as GameObject;
			}
		}

	public void PathWayDestroy(){
		if(wa != null)
		Destroy(HeroGamePlay.wa);

	}


	void CheckHeroClasses(){
	
	}




}

