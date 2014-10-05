using UnityEngine;
using System.Collections;

public class BoringEnemy : Enemy {

	// Use this for initialization
	void Init (Movement player) {
		baseSpeed = 1.0f;
		speedMod = 1.0f;
		aggroRadius = 3.0f;
		destLocation = transform.position;
		this.player = player;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	public override void explode(){
		base.explode();
		Destroy(gameObject);
	}

}
