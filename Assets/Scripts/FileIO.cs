using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileIO {

	public int[][] GetTilesFromFile(string fileName){
		TextAsset txt = (TextAsset) Resources.Load ("LevelFiles/" + fileName, typeof (TextAsset));
		string content = txt.text;
		List<string> lines = new List<string> (content.Split ('\n'));
		int[][] tiles = new int[lines.Count][];
		for (int i = 0; i < lines.Count; i++){
			string[] line = lines[i].Split(' ');
			tiles[i] = new int[line.Length];
			for (int j = 0; j < line.Length; j++){
				tiles[i][j] = int.Parse(line[j]);
			}
		}
		return tiles;
	}

	public void WriteTilesToFile(int[][] tiles, string fileName){
		string path = "Assets/Resources/LevelFiles/" + fileName + ".txt";
		StreamWriter sw;
		if (File.Exists(path)) {
			sw = new StreamWriter(path);
		}
		else {
			sw = File.CreateText(path);
		}

		for (int i = 0; i < tiles.Length; i++){
			string line = "";
			for (int j = 0; j < tiles[i].Length; j++){
				line += tiles[i][j].ToString();
				if (j < tiles[i].Length - 1) line += " ";
			}
			sw.WriteLine(line);
		}
		sw.Close();
	}

}
