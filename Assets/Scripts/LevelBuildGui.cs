using UnityEngine;
using System.Collections;

public class LevelBuildGui : MonoBehaviour {
	public GameObject player, slow_enemy, pounce_enemy,  fast_enemy, vision_tower, ranged_enemy;

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
		} else {
			menu = 0;
		}
	}
	void Object_Select(){
		Vector3 locale = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		locale.z = 0;
		if (select == "Player") {
						Instantiate (player, (locale), Quaternion.identity);
				} else if (select == "Fast Enemy") {
						Instantiate (fast_enemy, locale, Quaternion.identity);
				} else if (select == "Slow Enemy") {
						Instantiate (slow_enemy, (locale), Quaternion.identity);
				} else if (select == "Ranged Enemy") {
						Instantiate (ranged_enemy, (locale), Quaternion.identity);
				} else if (select == "Vision Tower") {
						Instantiate (vision_tower, (locale), Quaternion.identity);
				} else if (select == "Pounce Enemy") {
						Instantiate (pounce_enemy, (locale), Quaternion.identity);
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
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Export Level")) {
			menu = 6;
		}
	}
	void Player_Select(){
		if (GUI.Button (new Rect (10,  10 , 40, Screen.height * 0.05f), "X")) {
			menu = 0;
		}
		float offset = 0.0f;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Player")) {
			select = "Player";
		}
	}
	void Terrain_Select(){if (GUI.Button (new Rect (10,  10 , 40, Screen.height * 0.05f), "X")) {
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
	void Enemy_Select(){
		if (GUI.Button (new Rect (10,  10 , 40, Screen.height * 0.05f), "X")) {
			menu = 0;
		}
		float offset = 0.0f;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Slow Enemy")) {
			select = "Slow Enemy";
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Fast Enemy")) {
			select = "Fast Enemy";
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Pounce Enemy")) {
			select = "Pounce Enemy";
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Ranged Enemy")) {
			select = "Ranged Enemy";
		}
		offset += Screen.height * 0.05f + 5;
		if (GUI.Button (new Rect (10, Screen.height / 10 + offset, Screen.width / 4 - 20, Screen.height * 0.05f), "Vision Tower")) {
			select = "Vision Tower";
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
