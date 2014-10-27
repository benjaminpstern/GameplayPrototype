using UnityEngine;
using System.Collections;

public abstract class Enemy : Splodeable {

	public float baseSpeed = 1;
	protected float speedMod = 1; //speed modifier for traps
	protected float pushSpeed = 5;// speed that it can be pushed by a push mine
	public float aggroRadius = 1;
	public float killRadius = 1;
	protected Vector3 destLocation; //to find the player and kill it!!!
	public GameObject player;
	public bool inLineOfSight = false;
	protected Invisibility playerInvisibility;
	protected bool aggrod;
	public Vector3 velocity;
	public float maxAcceleration = 5;
	private bool pushed;

	//public abstract void Update();
	public void init(){
		playerInvisibility = player.GetComponent<Invisibility>();
	}
	//Accelerates in the direction of its destination. 
	//Normally its speed can't exceed baseSpeed * speedMod
	//but if it gets pushed by a push mine, it can go to pushSpeed
	public void move(float t){
		Vector3 curLocation = transform.position;
		Vector3 direction = destLocation - curLocation;
		float distanceToDest = direction.magnitude;
		Vector3 directionNormalized = direction.normalized;
		velocity += (direction * maxAcceleration * t);// * baseSpeed * speedMod * t);
		if(distanceToDest < 1){
			velocity *= distanceToDest;
		}
		if(velocity.magnitude > baseSpeed * speedMod && !pushed ){
			velocity = velocity.normalized * baseSpeed * speedMod;
		}
		else if( velocity.magnitude <= baseSpeed * speedMod && pushed ){
			pushed = false;
		}
		else if(pushed && velocity.magnitude > pushSpeed){
			velocity = velocity.normalized * pushSpeed;
		}
		
		transform.Translate (velocity * t);
	}

	public override void explode(){
		print ("Boom");
	}
	
	public override void push(Vector3 p){
		velocity = p;
		pushed = true;
	}

	//check if an object is in line of sight
	public bool inLoS(){
		return inLineOfSight;
	}

	//Determines whether the enemy should aggro.
	public bool shouldAggro( ){
		if (!player) return false;
		if(aggrod) return false;

		//In range of player.
		if( inLoS() && playerInvisibility.isVisible ) return true;

		GameObject[] fellows = GameObject.FindGameObjectsWithTag("Enemy");
		//In range of aggro'd enemy.
		for(int i = 0; i < fellows.Length; i++){
			Enemy e = fellows[i].GetComponent<Enemy>();
			if (Vector3.Distance(gameObject.transform.position, e.gameObject.transform.position) < aggroRadius && e.aggrod ) return true; //&& inLoS (fellows[i])
		}
		return false;
	}

}
