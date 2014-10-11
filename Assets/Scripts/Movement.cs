using UnityEngine;
using System.Collections;

public class Movement : Splodeable {
	public float baseSpeed = 2.0f;
	protected float speed;
	public float tilt = 1.0f;
	public float slowTime = 3f;
	public GameObject exit;
	void Start(){
		speed = baseSpeed;
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical,0.0f ).normalized;
		rigidbody2D.velocity = movement * speed;
		
		transform.rotation = Quaternion.Euler(0,0,0);
		
		if (Vector3.Distance(transform.position, exit.transform.position) < 0.1){
			Application.LoadLevel ("Scene2");
		}
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
