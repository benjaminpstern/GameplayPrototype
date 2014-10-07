using UnityEngine;
using System.Collections;

public class FastEnemy : Enemy {
	
	void Start () {
		baseSpeed = 2.0f;
		speedMod = 1.0f;
		aggroRadius = 3.0f;
		killRadius = 0.8f;
		aggrod = false;
		destLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( Vector3.Distance (transform.position, player.transform.position) < aggroRadius && player.renderer.material.shader == player.visible ) aggrod = true;
		if( player.renderer.material.shader == player.visible && inLoS(player.gameObject)) destLocation = player.transform.position;
		
		if(aggrod) move (Time.deltaTime);
		if( Vector3.Distance (transform.position, player.transform.position) <= killRadius) player.explode();
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