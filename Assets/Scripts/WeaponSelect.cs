using UnityEngine;
using System.Collections;

public class WeaponSelect : MonoBehaviour {

	public float screen_width = Screen.width;
	public float screen_height = Screen.height/10;
	public int left_Offset = 50;
	public int height_Offset = 40;
	public int button_Length = 80;
	public int button_Height = 20;
	public int button_Space = 10;

	private int keycode = 1;

	void Update(){
		if(Input.GetKey(KeyCode.Alpha1)){
			keycode = 1;
		}
		if(Input.GetKey(KeyCode.Alpha2)){
			keycode = 2;
		}
	}	

	void OnGUI(){
		// Make a background box
		screen_width = Screen.width;
		screen_height = Screen.height/10;
		GUI.Box(new Rect(0,0,screen_width,screen_height), "Mines");
		
		// Make the first button. 
		if(GUI.Button(new Rect(left_Offset,height_Offset,button_Length,button_Height), "Mine 1") || (keycode == 1)) {
			GUI.color = Color.red;
		}
		

		if(GUI.Button(new Rect(left_Offset+button_Length+button_Space,height_Offset,button_Length,button_Height), "Mine 2") || (keycode == 2)) {

		}
	}
}
