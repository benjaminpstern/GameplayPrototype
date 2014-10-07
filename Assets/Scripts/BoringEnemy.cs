using UnityEngine;
using System.Collections;

public class BoringEnemy : Enemy {

	void Start () {
		baseSpeed = 1.25f;
		speedMod = 1.0f;
		aggroRadius = 3.5f;
		killRadius = 1.25f;
		aggrod = false;
		destLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( shouldAggro() ) aggrod = true;
		if( player && player.renderer.material.shader == player.visible && inLoS(player.gameObject)) destLocation = player.transform.position;

		if(aggrod) move (Time.deltaTime);
		if( player && Vector3.Distance (transform.position, player.transform.position) <= killRadius) player.explode();
	}

	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy(this);
	}
	public override void slow ()
	{
		speedMod = .3f;
	}
}
