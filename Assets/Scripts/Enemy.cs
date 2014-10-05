using UnityEngine;
using System.Collections;

public abstract class Enemy : Splodeable {

	public float baseSpeed;
	public float speedMod; //speed modifier for traps
	public float aggroRadius;
	public Vector3 destLocation; //to find the player and kill it!!!
	public Movement player;

	//public abstract void Update();

	public void move(){
		Vector3 curLocation = transform.position;
		Vector3 direction = (destLocation - curLocation).normalized;
		transform.Translate(direction * baseSpeed * speedMod * Time.deltaTime);
	}

	public override void explode(){
		print ("Boom");
	}

}
