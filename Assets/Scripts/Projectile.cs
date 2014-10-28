using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public Vector3 direction;
	public float baseSpeed;
	public float speedMod;

	public void Start(){
		baseSpeed = .80f;
		speedMod = 1.0f;

	}

	void OnTriggerEnter2D( Collider2D other ){
		speedMod *= 1.01f;
		//GameObject player = GameObject.FindGameObjectWithTag("Player");
		if( other.tag == "Player" )	other.GetComponent<Movement>().explode();
		if( other.tag == "Wall" || other.tag == "Player" )Destroy(gameObject);
	}

	void Update( ){
		transform.Translate(direction * baseSpeed * speedMod * Time.deltaTime);
	}

}
