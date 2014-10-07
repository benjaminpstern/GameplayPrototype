using UnityEngine;
using System.Collections;

public class Movement : Splodeable {
	public float baseSpeed = 2.0f;
	protected float speed;
	public float tilt = 1.0f;
	public float slowTime = 3f;
	public Shader invis; 
	public Shader visible;
	float timer;
	void Start(){
		invis  = Shader.Find ("Transparent/Diffuse");
		visible = Shader.Find ("Sprites/Default");
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
		if (Input.GetKey (KeyCode.Space)) {
			//if(renderer.material.shader != invis){
					renderer.material.shader = invis;
					renderer.material.color = new Color(1,1,1,.5f);
		}if(Input.GetKey (KeyCode.Mouse0)){
			
					renderer.material.shader = visible;
					renderer.material.color = new Color(1,1,1,1);
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
