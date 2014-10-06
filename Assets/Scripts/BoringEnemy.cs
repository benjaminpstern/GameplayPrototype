using UnityEngine;
using System.Collections;

public class BoringEnemy : Enemy {

	void Init (Movement player) {
		baseSpeed = 1.0f;
		speedMod = 1.0f;
		aggroRadius = 3.0f;
		this.player = player;
	}
	
	// Update is called once per frame
	void Update () {
		destLocation = player.transform.position;
		move (Time.deltaTime);
	}

	public override void explode(){
		base.explode();
		Destroy(gameObject);
	}
	public override void slow ()
	{
		speedMod = .3f;
	}
}
