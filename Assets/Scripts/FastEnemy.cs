using UnityEngine;
using System.Collections;

public class FastEnemy : Enemy {
	
	void Start () {
		base.init ();
		baseSpeed *= 2.2f;
		speedMod *= 1.0f;
		aggroRadius *= 3.5f;
		killRadius *= 0.85f;
		aggrod = false;
		destLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( shouldAggro() ) aggrod = true;
		if( playerInvisibility.isVisible && inLoS()) destLocation = player.transform.position;
		if(aggrod) move (Time.deltaTime);
		if( player && Vector3.Distance (transform.position, player.transform.position) <= killRadius) 
			player.GetComponent<Movement>().explode();
	}
	
	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy (this);
	}
	public override void slow ()
	{
		speedMod *= .3f;
	}
}