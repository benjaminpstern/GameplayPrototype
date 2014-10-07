using UnityEngine;
using System.Collections;

public class Movement : Splodeable {
	public float baseSpeed = 2.0f;
	protected float speed;
	public float tilt = 1.0f;
	public float slowTime = 3f;

	float timer;
	void Start(){
	
		speed = baseSpeed;
		timer = 0;
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical,0.0f );
		rigidbody2D.velocity = movement * speed;
			
		if(Input.GetKey(KeyCode.Q)){
			transform.Rotate (new Vector3(0,2,0));
		}
	
		transform.rotation = Quaternion.Euler(0,0,0);
		if(timer > 0){
			timer -= Time.deltaTime;
			if(timer <= 0)
				unSlow();
		}
	}
	public override void explode(){
		Destroy(gameObject);
	}
	public override void slow ()
	{
		speed = baseSpeed/3;
		timer = slowTime;
	}
	public void unSlow ()
	{
		speed = baseSpeed;
	}
}
