using UnityEngine;
using System.Collections;
using System.IO;

public class LevelEditor : MonoBehaviour {
	private int[][] tiles;
	private FileIO io;
	public string inputFile;
	public string outputFile;

	public Transform wallTile;
	public Transform floorTile;

	// Use this for initialization
	void Start () {
		io = gameObject.AddComponent<FileIO>();
		LoadFile(inputFile);
		WriteFile(outputFile);
	}

	// Used by the LoadFile function to add tiles to the screen
	void LoadLevel(){
		if (tiles != null){
			for (int y = 1; y < tiles.Length; y++) {
				for (int x = 0; x < tiles[y].Length; x++) {
					if (tiles[y][x] == 0){
						Instantiate(floorTile, new Vector3(x, y, 1), Quaternion.identity);
					}
					else if (tiles[y][x] == 1){
						Instantiate(wallTile, new Vector3(x, y, 0), Quaternion.identity);
					}
					//more types of tiles coming up, e.g. kill zone
				}
			}
		}
		else {
			print ("There is no level yet.");		
		}
	}

	// Load a level from file
	void LoadFile(string fileName){
		string path = "Assets/Resources/LevelFiles/" + fileName + ".txt";
		if (fileName != "" && File.Exists(path)) {
			tiles = io.ReadFromFile(fileName);
		}
		LoadLevel();
	}

	// Write a level to file
	void WriteFile(string fileName){
		if (fileName != "") {
			io.WriteToFile(tiles, fileName);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
