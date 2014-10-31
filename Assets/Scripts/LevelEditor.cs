using UnityEngine;
using System.Collections;
using System.IO;

public class LevelEditor : MonoBehaviour {
	private int[][] tiles;
	private FileIO io;
	public string inputFile;
	public string outputFile;

	// Use this for initialization
	void Start () {
		io = new FileIO();
		LoadFile(inputFile);
		WriteFile(outputFile);
	}
	
	void LoadFile(string fileName){
		string path = "Assets/Resources/LevelFiles/" + fileName + ".txt";
		if (fileName != "" && File.Exists(path)) {
			tiles = io.GetTilesFromFile(fileName);
		}
	}

	void WriteFile(string fileName){
		if (fileName != "") {
			io.WriteTilesToFile(tiles, fileName);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
