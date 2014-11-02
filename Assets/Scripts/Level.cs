using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

public class Level : MonoBehaviour{

	public int [][] tiles;
	public Vector3 playerPosition;
	public Vector3 exitPosition;
	public Vector3[] boringEnemyPositions;
	public Vector3[] fastEnemyPositions;
	public Level(string fileName){
		TextAsset txt = (TextAsset) Resources.Load ("LevelFiles/" + fileName, typeof (TextAsset));
		string content = txt.text;
		List<string> lines = new List<string> (Regex.Split(content, "\r\n"));
		
		int tileStart = -1;
		int tileEnd = -1;
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "TILES") == 0){
				tileStart = i;
			}
		}
		for (int i = tileStart+1; i < lines.Count; i++){
			if (lines[i].Length == 0 || (string.Compare(lines[i][0].ToString(), "1") != 0 && string.Compare(lines[i][0].ToString(),"0") != 0)){
				tileEnd = i;
				break;
			}
		}
		if (tileStart != -1){
			if (tileEnd == -1) tileEnd = lines.Count;
			tiles = new int[tileEnd-tileStart-1][];
			int tilePosition = 0;
			for (int i = tileStart; i < tileEnd; i++){
				if (string.Compare(lines[i],"TILES" ) == 0) {
					continue;
				}
				string[] line = lines[i].Split(' ');
				tiles[tilePosition] = new int[line.Length];
				for (int j = 0; j < line.Length; j++){
					tiles[tilePosition][j] = int.Parse(line[j]);
				}
				tilePosition++;
			}
		}
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "PLAYER") == 0){
				string playerLine = lines[i+1];
				string[] playerLineSplit = playerLine.Split (' ');
				playerPosition = new Vector3(int.Parse (playerLineSplit[0]), int.Parse (playerLineSplit[1]),0);
			}
		}
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "EXIT") == 0){
				string exitLine = lines[i+1];
				string[] exitLineSplit = exitLine.Split (' ');
				exitPosition = new Vector3(int.Parse (exitLineSplit[0]), int.Parse (exitLineSplit[1]),0);
			}
		}
	}
	public void write(string fileName){
		string path = "Assets/Resources/LevelFiles/" + fileName + ".txt";

		StreamWriter sw;
		if (File.Exists(path)) {
			sw = new StreamWriter(path);
		}
		else {
			sw = File.CreateText(path);
		}

		sw.WriteLine("TILES");
		for (int i = 0; i < tiles.Length; i++){
			string line = "";
			for (int j = 0; j < tiles[i].Length; j++){
				line += tiles[i][j].ToString();
				if (j < tiles[i].Length - 1) line += " ";
			}
			sw.WriteLine(line);
		}

		sw.WriteLine("PLAYER");
		string playerLine = playerPosition[0].ToString() + " " + playerPosition[1].ToString();
		sw.WriteLine(playerLine);

		sw.WriteLine("EXIT");
		string exitLine = exitPosition[0].ToString() + " " + exitPosition[1].ToString();
		sw.WriteLine(exitLine);

		sw.Close();
	}
}
