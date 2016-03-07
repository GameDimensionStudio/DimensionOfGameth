using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class HeroBowGamePlay : MonoBehaviour {

	//Variable for position at Startpoint
	public float startpointX = 0;
	public float startpointy = 30;
	public float startpointZ = 200;

	//Variable for Hero Character's Info
	//public static string name;
	//public static string heroclass;
	public int HP = 500;
	public int Damage = 100;
	public static int mov = 1;



	//Variable for CreatePathway
	public static GameObject wa = null;
	public static GameObject aa = null;
	public static Vector3[] WalkableGrid;


	//Variable for Hero Walk to Destination
	public static Vector3 HeroCurrentPos;
	public static Vector3 HeroDestination;
	public Vector3 newPosition;
	public Vector3 targetPosition;
	[SerializeField] public static string SelfWalkStatus = "NO"; // YES = Allow to walk // No = Not allow to walk // Walking = it's walking
	[SerializeField] public static string SelfWalkState = "STOP";
	[SerializeField] public static string SelfClicking = "";
	[SerializeField] bool SelfAtkState = false;
	public static Vector3 CheckWalkFinish;
	public static float startspeed = 0.01f;
	float walkspeed = 0.015f;
	[SerializeField] bool startwalking = false;
	[SerializeField] GameObject gmObject;
	GameManager gm;
	NavMeshAgent nma;
	//Rigidbody rb;

	void Awake()
	{
		gmObject = GameObject.Find("GameManager");
		gm = (GameManager) gmObject.GetComponent(typeof(GameManager));
	}
	// Assign all start value for Hero
	void Start () {
		//HeroCurrentPos = transform.position = new Vector3 (startpointX, startpointy, startpointZ);
		nma = GetComponent<NavMeshAgent>();
		//rb = GetComponent<Rigidbody> ();
		//rb.velocity = Vector3.zero;
		//rb.angularVelocity = Vector3.zero;
		Debug.Log ("Test"+ nma.autoRepath);

	}

	/// Mouse Clink on Hero Event /// 
	void OnMouseDown(){
		 /*if (!isLocalPlayer) {
			return;
		}*/
		GameManager.MouseIsDown = true;
		CharacterControl ();
	}

	/// Deley timing Before Hero going to walk 
	IEnumerator DelayWalk (){
		yield return new WaitForSeconds (0.2f);
		SelfWalkState = "READY";
		SelfWalkStatus = "YES";
	}
	IEnumerator DelayAtk (){
		yield return new WaitForSeconds (0.2f);
	}



	// Update is called once per frame

	void CharacterControl()
	{
		/*if (!isLocalPlayer) {
			return;
		}*/

		if (/*SelfClicking != "HERO" && */SelfWalkState == "STOP" ) {
			GameManager.ClickingObject = "HEROBOW";
			AreaDestroy ();
			CreateWalkingArea (transform.position);
			SelfClicking = "HERO";
			StartCoroutine (DelayWalk ());

		}

		//print (HeroCurrentPos);
	}

	void Update () {
		/*if (!isLocalPlayer) {
			return;
		}*/
		if (SelfWalkState == "STOP") {
			//nma.updatePosition = false;
		
			Debug.Log ("NOW STOP");
		}
		Debug.Log ("Bow Hero : Walkstatus = "+ SelfWalkStatus +"/ WalkState = "+SelfWalkState+" / Clicking : "+SelfClicking);
		if (SelfWalkStatus != "WALKING" && SelfClicking != "HERO") {
			AreaDestroy ();
		}
		if(SelfWalkState == "FINISH")
		{
			SelfWalkState = "STOP";
		}
		if(SelfClicking == "Board") {
			SelfWalkStatus = "NO";
			SelfWalkState = "STOP";
		}
		if(GameManager.ClickingObject != "HEROBOW"){
			AreaDestroy ();
			SelfAtkState = false;
		}
		if (GameManager.ClickingObject == "Board") {
			SelfClicking = "Board";
			SelfAtkState = false;
		}
		ClickToWalk ();
		PressAttack ();
		ClickToAttack ();
		if (SelfWalkState == "WALKING" && SelfWalkStatus != "NO") {
			if(SelfWalkState != "FINISH"){
				print ("Mouse Position Value = " + targetPosition + "Hero Origin Postion =" + transform.position);
				//Walk (targetPosition);
				AgentWalk(targetPosition);
				//print (walkstatus);
			}
		}
	
	}

	void FixedUpdate(){
		/*if (!isLocalPlayer) {
			return;
		}*/



	}

	void AgentWalk(Vector3 Destination)
	{
		if (startwalking == false) {
			HeroCurrentPos = transform.position;
		}
		nma.ResetPath ();
		nma.SetDestination (Destination);
			CheckWalkFinish = Destination - transform.position;

		if (CheckWalkFinish.sqrMagnitude <= new Vector3 (38, 0, 38).sqrMagnitude) {
				//print ("Walk Finish : " + walkspeed + "walkstart = " + startspeed);
				SelfWalkState = "FINISH";
				SelfClicking = "";
				startwalking = false;
				startspeed = 0.01f;
			}
	}

	void PressAttack()
	{
		if (Input.GetKeyDown ("a") && SelfClicking == "HERO" && GameManager.ClickingObject == "HEROBOW") {
			AreaDestroy ();
			CreateAtkArea (transform.position);
			StartCoroutine (DelayAtk ());
			SelfAtkState = true;
		}
	}

	void ClickToAttack()
	{
		if (Input.GetMouseButtonDown (0) && SelfAtkState == true) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit; 
			if (Physics.Raycast (ray, out hit) && hit.transform.tag.Contains("Enemy")) {
				GameObject hitobject = hit.transform.gameObject;
				hitobject.SendMessage ("TakeDamage",Damage);

			}
		}
	}

	void ClickToWalk(){
		/*if (!isLocalPlayer) {
			return;
		}*/
		if (Input.GetMouseButtonDown (0) && SelfWalkStatus == "YES" && SelfWalkState == "READY") {

			print (SelfWalkStatus);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit) && hit.transform.tag == "BowWalkArea") {
				targetPosition = hit.point;
				//WalkRangeX = Mathf.Abs (targetPosition.x - transform.position.x);
				SelfWalkState = "WALKING";
				SelfClicking = "";
			}
			else{
				SelfWalkStatus = "NO";
				SelfWalkState = "STOP";
			}
		}
	}

	void Walk(Vector3 Destination){
		/*if (!isLocalPlayer) {
			return;
		}*/
		if (startwalking == false) {
			HeroCurrentPos = transform.position;
		}
		if (Destination != HeroCurrentPos) {
			transform.position = Vector3.Lerp (HeroCurrentPos,Destination,startspeed);
			transform.position= new Vector3(transform.position.x,50,transform.position.z);
			startspeed = walkspeed+startspeed;
			startwalking = true;
			print ("T : " + HeroCurrentPos + startwalking+ " / walkspeed = " /*+ walkspeed*/);
		}

		CheckWalkFinish = Destination - transform.position;
		if(CheckWalkFinish.sqrMagnitude <= new Vector3(38,0,38).sqrMagnitude) {
			//print ("Walk Finish : " + walkspeed + "walkstart = " + startspeed);
			SelfWalkState = "FINISH";
			SelfClicking = "";
			startwalking = false;
			startspeed = 0.01f;
		}
	}

	public void CreateWalkingArea(Vector3 currentPosition){
		//print ("this is ClinkedObject value " + SelfClicking);
		//if (SelfClicking != "HERO") {
			wa = Instantiate (Resources.Load ("Prefabs/HeroBow/BowWalkArea"), new Vector3 (currentPosition.x, currentPosition.y-35, currentPosition.z), Quaternion.Euler (0, 0, 0)) as GameObject;
		//}
	}

	public void CreateAtkArea(Vector3 currentPosition){
		//print ("this is ClinkedObject value " + SelfClicking);
		//if (SelfClicking == "HERO") {
			aa = Instantiate (Resources.Load ("Prefabs/HeroBow/BowAtkArea"), new Vector3 (currentPosition.x, currentPosition.y-35, currentPosition.z), Quaternion.Euler (0, 0, 0)) as GameObject;
		//}
	}

	public void AreaDestroy(){
		if(wa != null)
		{
			Destroy(HeroBowGamePlay.wa);
		}	
		if(aa != null)
		{
			Destroy(HeroBowGamePlay.aa);
		}
	}

	void TakeDamage(int IncomeDamage)
	{
		HP = HP - IncomeDamage;
		Debug.Log ("MY HP = "+HP);
	}
}
