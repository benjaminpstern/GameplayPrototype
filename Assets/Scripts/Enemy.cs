using UnityEngine;
using System.Collections;

public abstract class Enemy : Splodeable {

	public float baseSpeed = 1;
	protected float speedMod = 1; //speed modifier for traps
	public float aggroRadius = 1;
	public float killRadius = 1;
	protected Vector3 destLocation; //to find the player and kill it!!!
	public GameObject player;
	protected Invisibility playerInvisibility;
	protected bool aggrod;

	//public abstract void Update();
	public void init(){
		playerInvisibility = player.GetComponent<Invisibility>();
	}
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
//		print (hit.collider);
		if (hit.collider != null && hit.collider.gameObject == item) {
//			print ("in LoS");
			return true;
		}
		//print ("Out of LoS");
		return false;
	}

	//Determines whether the enemy should aggro.
	public bool shouldAggro( ){
		if (!player) return false;
		if(aggrod) return false;

		//In range of player.
		if( Vector3.Distance(gameObject.transform.position, player.transform.position) < aggroRadius && playerInvisibility.isVisible ) return true;

		GameObject[] fellows = GameObject.FindGameObjectsWithTag("Enemy");
		//In range of aggro'd enemy.
		for(int i = 0; i < fellows.Length; i++){
			Enemy e = fellows[i].GetComponent<Enemy>();
			if (Vector3.Distance(gameObject.transform.position, e.gameObject.transform.position) < aggroRadius && e.aggrod ) return true; //&& inLoS (fellows[i])
		}
		return false;
	}

}
