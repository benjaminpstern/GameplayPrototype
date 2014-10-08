using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public GameObject player;
	public GUIText gui_text;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == player.gameObject){
			gui_text.text = "You win!";
			WaitForSeconds wait = new WaitForSeconds(2);
			Application.LoadLevel ("Scene2");
		}
	}
}
