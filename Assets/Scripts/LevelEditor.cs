using UnityEngine;
using System.Collections;
using System.IO;

public class LevelEditor : MonoBehaviour {
	public Level level;
	public string inputFile;
	public string outputFile;

	public Transform wallTile;
	public Transform floorTile;
	public Transform player;
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
			for (int y = 0; y < level.tiles.Length; y++) {
				for (int x = 0; x < level.tiles[y].Length; x++) {
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
			for (int y = 0; y < level.tiles.Length; y++) {
				for (int x = 0; x < level.tiles[y].Length; x++) {
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
		Instantiate(player, level.playerPosition, Quaternion.identity);
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
