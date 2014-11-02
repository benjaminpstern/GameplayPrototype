using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

public class Level : MonoBehaviour{

	public int [][] tiles;
	public Vector3 playerPosition;
	public Vector3 exitPosition;
	public Vector3[] slowEnemyPositions;
	public Vector3[] fastEnemyPositions;
	public Vector3[] pounceEnemyPositions;
	public Vector3[] rangedEnemyPositions;
	public Vector3[] towerPositions;
	public Vector3[] deadZonePositions;

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
				string[] playerLineSplit = playerLine.Split (',');
				playerPosition = new Vector3(float.Parse (playerLineSplit[0]), float.Parse (playerLineSplit[1]),0);
				break;
			}
		}

		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "EXIT") == 0){
				string exitLine = lines[i+1];
				string[] exitLineSplit = exitLine.Split (',');
				exitPosition = new Vector3(int.Parse (exitLineSplit[0]), int.Parse (exitLineSplit[1]),0);
				break;
			}
		}

		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "SLOW ENEMY") == 0){
				string BELine = lines[i+1];
				string[] BELineSplit = BELine.Split (' ');
				slowEnemyPositions = new Vector3[BELineSplit.Length];
				for (int j = 0; j < BELineSplit.Length; j++) {
					string[] BE = BELineSplit[j].Split(',');
					slowEnemyPositions[j] = new Vector3(float.Parse(BE[0]), float.Parse(BE[1]), 0);
				}
				break;
			}
		}

		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "FAST ENEMY") == 0){
				string FELine = lines[i+1];
				string[] FELineSplit = FELine.Split (' ');
				fastEnemyPositions = new Vector3[FELineSplit.Length];
				for (int j = 0; j < FELineSplit.Length; j++) {
					string[] FE = FELineSplit[j].Split(',');
					fastEnemyPositions[j] = new Vector3(float.Parse(FE[0]), float.Parse(FE[1]), 0);
				}
				break;
			}
		}

		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "POUNCE ENEMY") == 0){
				string PELine = lines[i+1];
				string[] PELineSplit = PELine.Split (' ');
				pounceEnemyPositions = new Vector3[PELineSplit.Length];
				for (int j = 0; j < PELineSplit.Length; j++) {
					string[] PE = PELineSplit[j].Split(',');
					pounceEnemyPositions[j] = new Vector3(float.Parse(PE[0]), float.Parse(PE[1]), 0);
				}
				break;
			}
		}

		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "RANGED ENEMY") == 0){
				string RELine = lines[i+1];
				string[] RELineSplit = RELine.Split (' ');
				rangedEnemyPositions = new Vector3[RELineSplit.Length];
				for (int j = 0; j < RELineSplit.Length; j++) {
					string[] RE = RELineSplit[j].Split(',');
					rangedEnemyPositions[j] = new Vector3(float.Parse(RE[0]), float.Parse(RE[1]), 0);
				}
				break;
			}
		}

		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "TOWER") == 0){
				string RELine = lines[i+1];
				string[] RELineSplit = RELine.Split (' ');
				towerPositions = new Vector3[RELineSplit.Length];
				for (int j = 0; j < RELineSplit.Length; j++) {
					string[] RE = RELineSplit[j].Split(',');
					towerPositions[j] = new Vector3(float.Parse(RE[0]), float.Parse(RE[1]), 0);
				}
				break;
			}
		}

		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "DEAD ZONE") == 0){
				string RELine = lines[i+1];
				string[] RELineSplit = RELine.Split (' ');
				deadZonePositions = new Vector3[RELineSplit.Length];
				for (int j = 0; j < RELineSplit.Length; j++) {
					string[] RE = RELineSplit[j].Split(',');
					deadZonePositions[j] = new Vector3(float.Parse(RE[0]), float.Parse(RE[1]), 0);
				}
				break;
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
		string playerLine = playerPosition[0].ToString() + "," + playerPosition[1].ToString();
		sw.WriteLine(playerLine);

		sw.WriteLine("EXIT");
		string exitLine = exitPosition[0].ToString() + "," + exitPosition[1].ToString();
		sw.WriteLine(exitLine);

		sw.WriteLine("SLOW ENEMY");
		string boringEnemyLine = "";
		for (int i = 0; i < slowEnemyPositions.Length; i++){
			boringEnemyLine += slowEnemyPositions[i][0].ToString() + "," + slowEnemyPositions[i][1].ToString();
			if (i < slowEnemyPositions.Length - 1){
				boringEnemyLine += " ";
			}
		}
		sw.WriteLine(boringEnemyLine);

		sw.WriteLine("FAST ENEMY");
		string fastEnemyLine = "";
		for (int i = 0; i < fastEnemyPositions.Length; i++){
			fastEnemyLine += fastEnemyPositions[i][0].ToString() + "," + fastEnemyPositions[i][1].ToString();
			if (i < fastEnemyPositions.Length - 1){
				fastEnemyLine += " ";
			}
		}
		sw.WriteLine(fastEnemyLine);

		sw.WriteLine("POUNCE ENEMY");
		string pounceEnemyLine = "";
		for (int i = 0; i < pounceEnemyPositions.Length; i++){
			pounceEnemyLine += pounceEnemyPositions[i][0].ToString() + "," + pounceEnemyPositions[i][1].ToString();
			if (i < pounceEnemyPositions.Length - 1){
				pounceEnemyLine += " ";
			}
		}
		sw.WriteLine(pounceEnemyLine);

		sw.WriteLine("RANGED ENEMY");
		string rangedEnemyLine = "";
		for (int i = 0; i < rangedEnemyPositions.Length; i++){
			rangedEnemyLine += rangedEnemyPositions[i][0].ToString() + "," + rangedEnemyPositions[i][1].ToString();
			if (i < rangedEnemyPositions.Length - 1){
				rangedEnemyLine += " ";
			}
		}
		sw.WriteLine(rangedEnemyLine);

		sw.WriteLine("TOWER");
		string towerLine = "";
		for (int i = 0; i < towerPositions.Length; i++){
			towerLine += towerPositions[i][0].ToString() + "," + towerPositions[i][1].ToString();
			if (i < towerPositions.Length - 1){
				towerLine += " ";
			}
		}
		sw.WriteLine(towerLine);

		sw.WriteLine("DEAD ZONE");
		string deadZoneLine = "";
		for (int i = 0; i < deadZonePositions.Length; i++){
			deadZoneLine += deadZonePositions[i][0].ToString() + "," + deadZonePositions[i][1].ToString();
			if (i < deadZonePositions.Length - 1){
				deadZoneLine += " ";
			}
		}
		sw.WriteLine(deadZoneLine);

		sw.Close();
	}
}
