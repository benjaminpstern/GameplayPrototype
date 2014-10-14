using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	public float frameSize;

	// Use this for initialization
	void Start () {
		offset = transform.position;
		camera.orthographicSize = frameSize;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
