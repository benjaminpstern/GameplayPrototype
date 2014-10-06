using UnityEngine;
using System.Collections;

public abstract class Enemy : Splodeable {

	public float baseSpeed;
	protected float speedMod; //speed modifier for traps
	public float aggroRadius;
	protected Vector3 destLocation; //to find the player and kill it!!!
	public Movement player;

	//public abstract void Update();

	public void move(float t){
		Vector3 curLocation = transform.position;
		Vector3 direction = (destLocation - curLocation).normalized;
		transform.Translate(direction * 3 * t);// * baseSpeed * speedMod * t);
	}

	public override void explode(){
		print ("Boom");
	}

}
