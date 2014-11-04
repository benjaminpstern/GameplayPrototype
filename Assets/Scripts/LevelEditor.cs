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

	// Use this for initialization
	void Start () {
		level = new Level(inputFile);
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
		Instantiate(playerSprite, level.playerPosition, Quaternion.identity);
		Instantiate (exit, level.exitPosition, Quaternion.identity);
	}
	void PlayTestLevel(){
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
		GameObject myPlayer = Instantiate(player, level.playerPosition, Quaternion.identity) as GameObject; 
		myPlayer.transform.parent = splodeables.transform;
		
		for(int i=0;i<level.slowEnemyPositions.Count;i++){
			GameObject enemy = Instantiate(slowEnemy, level.slowEnemyPositions[i], Quaternion.identity) as GameObject;
			enemy.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.fastEnemyPositions.Count;i++){
			GameObject enemy = Instantiate(fastEnemy, level.fastEnemyPositions[i], Quaternion.identity) as GameObject;
			enemy.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.pounceEnemyPositions.Count;i++){
			GameObject enemy = Instantiate(pounceEnemy, level.pounceEnemyPositions[i], Quaternion.identity) as GameObject;
			enemy.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.rangedEnemyPositions.Count;i++){
			GameObject enemy = Instantiate(rangedEnemy, level.rangedEnemyPositions[i], Quaternion.identity) as GameObject;
			enemy.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.towerPositions.Count;i++){
			GameObject enemy = Instantiate(tower, level.towerPositions[i], Quaternion.identity) as GameObject;
			enemy.transform.parent = splodeables.transform;
		}
		Instantiate (exit, level.exitPosition, Quaternion.identity);
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
	
	}
}
