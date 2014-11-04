using UnityEngine;
using System.Collections;

public class CameraLevelBuilder:  MonoBehaviour  {
	public float baseSpeed = 2.0f;//speed under normal conditions
	private float slowTime = 5;
	protected float speed;//current speed

	public GameObject player;

	private LevelBuildGui script;
	private GameObject spawn;

	void Start(){
		spawn = GameObject.FindWithTag ("GameController");
		script = spawn.GetComponent<LevelBuildGui> ();
	}

	void Update(){
//		if (!script.play) {
			if (Input.GetKeyDown (KeyCode.J)) {
				transform.position = new Vector3 (transform.position.x - 0.5f, transform.position.y, transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.K)) {
				transform.position = new Vector3 (transform.position.x, transform.position.y - 0.5f, transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.L)) {
				transform.position = new Vector3 (transform.position.x + 0.5f, transform.position.y, transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.I)) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
			}
//		} 
	}

	}

