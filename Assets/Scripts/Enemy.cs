﻿using UnityEngine;
using System.Collections;

public abstract class Enemy : Splodeable {

	public float baseSpeed = 1;
	protected float speedMod = 1; //speed modifier for traps
	protected float pushSpeed = 10;// speed that it can be pushed by a push mine
	public float aggroRadius = 1;
	public float killRadius = 1;
	public float slowTime = 5;
	protected Vector3 destLocation; //to find the player and kill it!!!
	public GameObject player;
	public bool inLineOfSight = false;
	protected Invisibility playerInvisibility;
	public bool aggrod;
	public Vector3 velocity;
	public float maxAcceleration = 5;
	private bool pushed;
	private Vector3 pushedVelocity;
	private float slowTimer;

	//public abstract void Update();
	public void init(){
		player = GameObject.FindGameObjectWithTag("Player");
		playerInvisibility = player.GetComponent<Invisibility>();
	}
	//Accelerates in the direction of its destination. 
	//Normally its speed can't exceed baseSpeed * speedMod
	//but if it gets pushed by a push mine, it can go to pushSpeed
	public void move(float t){
		if(speedMod < 1){
			slowTimer -= t;
		}
		if (slowTimer < 0){
			speedMod = 1;
		}
		Vector3 curLocation = transform.position;
		float distToDest = (destLocation - curLocation).magnitude;
		Vector3 direction = (destLocation - curLocation).normalized;
		velocity += (direction * maxAcceleration * t);// * baseSpeed * speedMod * t);
		if(distToDest < 1){
			velocity *= distToDest;
		}
		if(velocity.magnitude > baseSpeed * speedMod && !pushed ){
			velocity = velocity.normalized * baseSpeed * speedMod;
		}
		else if( (velocity.magnitude <= baseSpeed * speedMod || 
		Mathf.Acos (Vector3.Dot (velocity.normalized, pushedVelocity.normalized)) > .3 ) && pushed ){
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
		pushedVelocity = velocity;
	}

	//used for the flash mine
	public override void blind(float t){
		
	}

	//check if an object is in line of sight
	public bool inLoS(){
		return inLineOfSight;
	}
	public override void slow ()
	{
		speedMod *= .3f;
		slowTimer = slowTime;
	}
	//Determines whether the enemy should aggro.
	public bool shouldAggro( ){
		if (!player) return false;
		if(aggrod) return false;

		//In range of player.
		if( inLoS() && playerInvisibility.isVisible && (player.transform.position - this.transform.position).magnitude < aggroRadius ) return true;

		GameObject[] fellows = GameObject.FindGameObjectsWithTag("Enemy");
		//In range of aggro'd enemy.
		for(int i = 0; i < fellows.Length; i++){
			print(fellows[i]);
			Enemy e = fellows[i].GetComponentInChildren<Enemy>();
			if (Vector3.Distance(gameObject.transform.position, e.gameObject.transform.position) < aggroRadius && e.aggrod ) return true; //&& inLoS (fellows[i])
		}
		return false;
	}



}
