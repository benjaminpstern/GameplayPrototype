using UnityEngine;
using System.Collections;

public class Movement : Splodeable {
	public float baseSpeed = 2.0f;//speed under normal conditions
	protected float speed;//current speed
	void Start(){
		speed = baseSpeed;
	}
	void Update(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical,0.0f ).normalized;
		rigidbody2D.velocity = movement * speed;
		
		transform.rotation = Quaternion.Euler(0,0,0);
	}
	public override void explode(){//what happens when you explode.
		lose();
	}
	public override void slow(){//what happens when you get slowed down
		speed *= .5f;
	}
	public void unSlow ()
	{
		speed = baseSpeed;
	}
	public void lose(){//what happens when you lose
		Application.LoadLevel ("Scene1");
	}
}
