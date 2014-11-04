using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LevelEditor : MonoBehaviour {
	public Level level;
	public string inputFile;
	public string outputFile;
	
	public Transform wallTile;
	public Transform floorTile;
	public Transform player;
	public Transform slowEnemy;
	public Transform fastEnemy;
	public Transform pounceEnemy;
	public Transform rangedEnemy;
	public Transform tower;
	public Transform playerSprite;
	public Transform exit;
	
	//Things for Stuff
	private Vector3 downPlace;
	public Transform curthing;
	public Camera camera;

	// Use this for initialization
	void Start () {
		level = new Level(inputFile);
		print(level);
		DisplayLevel();
		level.write(outputFile);
	}

	void DisplayLevel(){
		if (level.tiles != null){
			for (int y = 0; y < level.tiles.Count; y++) {
				for (int x = 0; x < level.tiles[y].Count; x++) {
					if (level.tiles[y][x] == 0){
						Instantiate(floorTile, new Vector3(x, y, 1), Quaternion.identity);
					}
					else if (level.tiles[y][x] == 1){
						Instantiate(wallTile, new Vector3(x, y, 0), Quaternion.identity);
					}
					//more types of tiles coming up, e.g. kill zone
				}
			}
		}
		else {
			print ("There is no level yet.");		
		}
		//Instantiate(playerSprite, level.playerPosition, Quaternion.identity);
		//Instantiate (exit, level.exitPosition, Quaternion.identity);
	}
	public void PlayTestLevel(){
		level.write (outputFile);
		level = new Level(outputFile);
		if (level.tiles != null){
			for (int y = 0; y < level.tiles.Count; y++) {
				for (int x = 0; x < level.tiles[y].Count; x++) {
					if (level.tiles[y][x] == 0){
						Instantiate(floorTile, new Vector3(x, y, 1), Quaternion.identity);
					}
					else if (level.tiles[y][x] == 1){
						Instantiate(wallTile, new Vector3(x, y, 0), Quaternion.identity);
					}
					//more types of tiles coming up, e.g. kill zone
				}
			}
		}
		else {
			print ("There is no level yet.");		
		}
		GameObject splodeables = new GameObject();
		Transform myPlayer = Instantiate(player, level.playerPosition, Quaternion.identity) as Transform; 
		myPlayer.parent = splodeables.transform;
		
		for(int i=0;i<level.slowEnemyPositions.Count;i++){
			Transform enemy = Instantiate(slowEnemy, level.slowEnemyPositions[i], Quaternion.identity) as Transform;
			enemy.parent = splodeables.transform;
		}
		for(int i=0;i<level.fastEnemyPositions.Count;i++){
			Transform enemy = Instantiate(fastEnemy, level.fastEnemyPositions[i], Quaternion.identity) as Transform;
			enemy.parent = splodeables.transform;
		}
		for(int i=0;i<level.pounceEnemyPositions.Count;i++){
			Transform enemy = Instantiate(pounceEnemy, level.pounceEnemyPositions[i], Quaternion.identity) as Transform;
			enemy.parent = splodeables.transform;
		}
		for(int i=0;i<level.rangedEnemyPositions.Count;i++){
			Transform enemy = Instantiate(rangedEnemy, level.rangedEnemyPositions[i], Quaternion.identity) as Transform;
			enemy.parent = splodeables.transform;
		}
		for(int i=0;i<level.towerPositions.Count;i++){
			Transform enemy = Instantiate(tower, level.towerPositions[i], Quaternion.identity) as Transform;
			enemy.parent = splodeables.transform;
		}
		Instantiate (exit, level.exitPosition, Quaternion.identity);
	}
	//Remember the position of the mouse when it was pushed down, rounded to nearest square.
	public void fOnMouseDown( ){
		downPlace = camera.ScreenToWorldPoint(Input.mousePosition);
		downPlace.x = Mathf.Round(downPlace.x);
		downPlace.y = Mathf.Round(downPlace.y);
	}
	
	//Do the thing with the placement and the stuff.
	public void fOnMouseUp( ){
		Vector3 upPlace = camera.ScreenToWorldPoint(Input.mousePosition);
		
		
		if( upPlace.x > -4 ){
			print(curthing.tag);
			if (curthing.tag == "enemy" || curthing.tag == "Enemy") Instantiate(curthing, new Vector3(upPlace.x, upPlace.y, 0), Quaternion.identity);
			else {
				upPlace.x = Mathf.Round(upPlace.x);
				upPlace.y = Mathf.Round(upPlace.y);
				for( int xcoord = (int)downPlace.x; xcoord <= upPlace.x; xcoord++ ){
					for( int ycoord = (int)downPlace.y; ycoord >= upPlace.y; ycoord-- ){
						Instantiate(curthing, new Vector3(xcoord, ycoord, 0), Quaternion.identity);
						//thisOne.transform.position = new Vector3(xcoord, ycoord, 0);
					}
				}
			}
		}
	}
	
	
	
	
	//
	//	// Load a level from file
	//	void LoadFile(string fileName){
	//		string path = "Assets/Resources/LevelFiles/" + fileName + ".txt";
	//		if (fileName != "" && File.Exists(path)) {
	//			tiles = io.ReadFromFile(fileName);
	//		}
	//		LoadLevel();
	//	}
	
	// Write a level to file
	/*void WriteFile(string fileName){
		if (fileName != "") {
			io.WriteToFile(tiles, fileName);
		}
	}*/
	
	// Update is called once per frame
	void Update () {
		curthing = camera.GetComponent<LevelBuildGui>().curThing.transform;
		if (Input.GetMouseButtonDown(0)) fOnMouseDown();
		if (Input.GetMouseButtonUp(0)) fOnMouseUp();
	}
}
