using UnityEngine;
using System.Collections;

public class LevelBuildGui : MonoBehaviour {
	
	//splodables
	public GameObject player, slow_enemy, pounce_enemy,  fast_enemy, vision_tower, ranged_enemy;
	//Other.
	public GameObject floor_tile, wall_tile, exit;
	//Current thingy.
	public GameObject curThing;
	//Level Editor Variable
	public GameObject GM;
	
	public KeyCode Delete = KeyCode.A;
	public bool play = false;
	
	private int menu = 0;
	private string select = "none";
	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			Object_Select();
		}
		if (Input.GetMouseButtonDown (2) || Input.GetKeyDown (Delete)) {
			select = "none";
		}if (Input.GetKeyDown (KeyCode.Space)){
			play = true;
			select = "playmode";
		}
	}
	void OnGUI(){
		GUI.Box (new Rect (Screen.width*0.70f, 0, Screen.width/4, Screen.height/25), "SELECTION: "+select);
		
		if (menu == 0) {
			GUI.Box (new Rect (0, 0, Screen.width / 4, Screen.height), "EDITOR");
			Main_Select ();
		} else if (menu == 1) {
			GUI.Box (new Rect (0, 0, Screen.width / 4, Screen.height), "PLAYER OBJECTS");
			Player_Select ();
		} else if (menu == 2) {
			GUI.Box (new Rect (0, 0, Screen.width / 4, Screen.height), "TERRAIN/OBJECTS");
			Terrain_Select ();
		} else if (menu == 3) {
			GUI.Box (new Rect (0, 0, Screen.width / 4, Screen.height), "ENEMY OBJECTS");
			Enemy_Select ();
		} else if (menu == 4) {
			GUI.Box (new Rect (0, 0, Screen.width / 4, Screen.height), "MINES");
			Mine_Select ();
		} else if (menu == 5) {
			GUI.Box (new Rect (0, 0, Screen.width / 4, Screen.height), "RESOURCES");
			Resource_Select ();
		}else if (menu == 6) {
			GUI.Box (new Rect (0, 0, Screen.width / 4, Screen.height), "PLAYTEST");
			LevelEditor le = GM.GetComponent<LevelEditor>();
			le.PlayTestLevel();
		}else if (menu == 7) {
			GUI.Box (new Rect (0, 0, Screen.width / 4, Screen.height), "EXPORT");
			LevelEditor gm = GM.GetComponent <LevelEditor>();
			gm.level.write(gm.outputFile);
			//Export_Select ();
		}else {
			menu = 0;
		}
	}
	void Object_Select(){
		Vector3 locale = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		locale.z = 0;
		if (select == "Player") {
			curThing = player;
		} else if (select == "Fast Enemy") {
			curThing = fast_enemy;
		} else if (select == "Slow Enemy") {
			curThing = slow_enemy;
		} else if (select == "Ranged Enemy") {
			curThing = ranged_enemy;
		} else if (select == "Vision Tower") {
			curThing = vision_tower;
		} else if (select == "Pounce Enemy") {
			curThing = pounce_enemy;
		} else if (select == "Wall") {
			curThing = wall_tile;
		} else if (select == "Floor") {
			curThing = floor_tile;
		}else if (select == "Exit") {
			curThing = exit;
		}
		
		
	}
	void Main_Select(){
		float offset = 0.0f;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Player")) {
			menu = 1;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Objects/Terrain")) {
			menu = 2;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Enemies")) {
			menu = 3;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Mines")) {
			menu = 4;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Resource Preset")) {
			menu = 5;
		}
		offset += Screen.height * 0.05f + 10;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Playtest")) {
			menu = 6;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Export Level")) {
			menu = 7;
		}
	}
	void Player_Select(){
		if (GUI.Button (new Rect (10,  10 , 40, Screen.height * 0.05f), "X")) {
			menu = 0;
		}
		float offset = 0.0f;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Player")) {
			select = "Player";
			curThing = player;
		}
	}
	void Terrain_Select(){if (GUI.Button (new Rect (10,  10 , 40, Screen.height * 0.05f), "X")) {
			menu = 0;
		}
		float offset = 0.0f;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Floor")) {
			select = "Floor";
			curThing = floor_tile;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Wall")) {
			select = "Wall";
			curThing = wall_tile;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Exit")) {
			select = "Exit";
			curThing = exit;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
	}
	void Enemy_Select(){
		if (GUI.Button (new Rect (10,  10 , 40, Screen.height * 0.05f), "X")) {
			menu = 0;
		}
		float offset = 0.0f;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Slow Enemy")) {
			select = "Slow Enemy";
			curThing = slow_enemy;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Fast Enemy")) {
			select = "Fast Enemy";
			curThing = fast_enemy;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Pounce Enemy")) {
			select = "Pounce Enemy";
			curThing = pounce_enemy;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Ranged Enemy")) {
			select = "Ranged Enemy";
			curThing = ranged_enemy;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Vision Tower")) {
			select = "Vision Tower";
			curThing = vision_tower;
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
	}
	void Mine_Select(){
		if (GUI.Button (new Rect (10,  10 , 40, Screen.height * 0.05f), "X")) {
			menu = 0;
		}
		float offset = 0.0f;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
	}
	void Resource_Select(){
		if (GUI.Button (new Rect (10, 10, 40, Screen.height * 0.05f), "X")) {
			menu = 0;
		}
		float offset = 0.0f;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "")) {
			
		}
	}
}