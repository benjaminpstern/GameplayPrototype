using UnityEngine;
using System.Collections;

public abstract class Enemy : Splodeable {

	public float baseSpeed;
	protected float speedMod; //speed modifier for traps
	public float aggroRadius;
	public float killRadius;
	protected Vector3 destLocation; //to find the player and kill it!!!
	public Movement player;
	protected bool aggrod;

	//public abstract void Update();

	public void move(float t){
		Vector3 curLocation = transform.position;
		Vector3 direction = (destLocation - curLocation).normalized;
		transform.Translate(direction * baseSpeed * speedMod * t);// * baseSpeed * speedMod * t);
	}

	public override void explode(){
		print ("Boom");
	}

	//check if an object is in line of sight
	public bool inLoS(GameObject item){
		RaycastHit2D hit = Physics2D.Raycast(transform.position, item.transform.position - transform.position );
		print (hit.collider);
		if (hit.collider != null && hit.collider.gameObject == item) {
			print ("in LoS");
			return true;
		}
		//print ("Out of LoS");
		return false;
	}

}
