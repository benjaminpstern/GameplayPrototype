using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
	public float speed = 1.0f;
	public bool move = false;
	private GameObject playerObject; 
	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindWithTag ("Player");
		if (playerObject == null) {
						Debug.Log ("Can't find player object!");
				}

	}
	
	// Update is called once per frame
	 void Update () {
		if (move) {
						float pace = speed * Time.deltaTime;
						Vector3 target = playerObject.transform.position;

						transform.position = Vector3.MoveTowards (transform.position, target, pace);
				}
	}
}
