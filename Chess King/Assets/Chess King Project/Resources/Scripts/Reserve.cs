using UnityEngine;
using System.Collections;

public class Reserve : MonoBehaviour {
	public GameObject[] grid = new GameObject[600];
	public GameObject[] tw1;
	public Vector3[] WalkableGrid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void CreatePathway(Vector3 currentPosition){
		print ("this is ClinkedObject value " + GameManager.ClickingObject);
		tw1 = new GameObject[13];

		if (GameManager.ClickingObject != "Hero") {
			tw1 [0] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x - 200, currentPosition.y - 40, currentPosition.z), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [1] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x - 100, currentPosition.y - 40, currentPosition.z - 100), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [2] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x - 100, currentPosition.y - 40, currentPosition.z), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [3] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x - 100, currentPosition.y - 40, currentPosition.z + 100), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [4] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x, currentPosition.y - 40, currentPosition.z - 200), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [5] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x, currentPosition.y - 40, currentPosition.z - 100), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [6] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x, currentPosition.y - 40, currentPosition.z), Quaternion.Euler (0, 0, 0)) as GameObject;
			;
			tw1 [7] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x, currentPosition.y - 40, currentPosition.z + 100), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [8] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x, currentPosition.y - 40, currentPosition.z + 200), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [9] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x + 100, currentPosition.y - 40, currentPosition.z - 100), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [10] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x + 100, currentPosition.y - 40, currentPosition.z), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [11] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x + 100, currentPosition.y - 40, currentPosition.z + 100), Quaternion.Euler (0, 0, 0)) as GameObject;
			tw1 [12] = Instantiate (Resources.Load ("Prefabs/TileWay"), new Vector3 (currentPosition.x + 200, currentPosition.y - 40, currentPosition.z), Quaternion.Euler (0, 0, 0)) as GameObject;

			WalkableGrid = new Vector3[tw1.Length];
			for (int i=0; i < tw1.Length; i++) {
				WalkableGrid[i] = tw1 [i].transform.position;
				print ("ALL Walkable Postion" + WalkableGrid[i]);
			}


		}
	}

	void CreateGrid(){

		float GridZ = 50;
		float GridX = 50;
		for (int i = 0;i < 600;i++)
		{
			int y = 0;
			print ("GridCreate now");
			if(GridX == 50 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 150;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 150 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 250;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 250 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 350;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 350 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 450;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 450 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 550;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 550 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 650;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 650 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 750;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 750 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 850;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 850 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 950;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 950 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 1050;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 1050 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 1150;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 1150 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 1250;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 1250 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 1350;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 1350 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 1450;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 1450 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 1550;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(GridX == 1550 && GridZ <= 1950){
				grid[y] = Instantiate(Resources.Load("Prefabs/GridTileWay"), new Vector3(GridX,5,GridZ), Quaternion.Euler(0, 0, 0)) as GameObject;
				GridZ = GridZ + 100;
				y++;
				if(GridZ > 1950){
					GridX = 1550;
					GridZ = 50;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		}



	}
}




