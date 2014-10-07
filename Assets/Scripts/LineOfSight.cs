/*Peter Aguiar
 * 10/6/2014
 * LineOfSight creates basic line of sight for an enemy 
 * that does not see through "barriers".
 * cs 361
 */
using UnityEngine;
using System.Collections;

public class LineOfSight : MonoBehaviour {

	public bool spotted = false;
	public int playerLayer;
	private Kill playerScript;

	void Start(){
				GameObject playerObject = GameObject.FindWithTag ("Enemy");
				if (playerObject != null) {
						playerScript = playerObject.GetComponent <Kill> (); 
				}
				if (playerObject == null) {
						Debug.Log ("Can't find player object!");
				}
		}
	void Update () {

		if (spotted && playerScript != null) {
						playerScript.move = true;

				} else {
						playerScript.move = false;
				}
	}

	void sight(Transform other){
				//bool vision = false;
		Debug.DrawLine (transform.position, other.position, Color.red);
		if (!Physics2D.Linecast (transform.position, other.position, 1 << LayerMask.NameToLayer ("Barrier"))) {
						spotted = Physics2D.Linecast (transform.position, other.position, 1 << LayerMask.NameToLayer ("Player"));
				} else {
						spotted = false;
				}
	}
	void OnTriggerStay2D (Collider2D other){


		if(other.tag == "Player"){

			sight(other.transform);
		}
	}
	void OnTriggerExit2D(Collider2D other){
				if (other.tag == "Player") {
						spotted = false;
				}
		}
	                                     



}
