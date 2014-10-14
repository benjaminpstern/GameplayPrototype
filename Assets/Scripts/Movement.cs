using UnityEngine;
using System.Collections;

public class Movement : Splodeable {
	public float baseSpeed = 2.0f;
	protected float speed;
	public float slowTime = 3f;
	void Start(){
		speed = baseSpeed;
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical,0.0f ).normalized;
		rigidbody2D.velocity = movement * speed;
		
		transform.rotation = Quaternion.Euler(0,0,0);
	}
	public override void explode(){
		lose();
	}
	public override void slow(){
		speed *= .5f;
	}
	public void unSlow ()
	{
		speed = baseSpeed;
	}
	public void lose(){
		Application.LoadLevel ("Scene1");
	}
}
