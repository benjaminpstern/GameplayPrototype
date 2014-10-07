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
	public float invisijuice = 5;
	public GUIText gui_text;
	public bool isVisible = true;
	public GameObject exit;
	void Start(){
		invis  = Shader.Find ("Transparent/Diffuse");
		visible = Shader.Find ("Sprites/Default");
		speed = baseSpeed;
		timer = 0;
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(isVisible){
				renderer.material.shader = invis;
				renderer.material.color = new Color(1,1,1,.5f);
				isVisible = false;
			}
			else{
				renderer.material.shader = visible;
				renderer.material.color = new Color(1,1,1,1);
				isVisible = true;
			}
		}
		if (invisijuice <= 0 && isInvisible()){
			renderer.material.shader = visible;
			renderer.material.color = new Color(1,1,1,1);
			isVisible = true;
			invisijuice = 0.0f;
		}
	}
	void FixedUpdate(){
		float deltaTime = Time.deltaTime;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical,0.0f );
		rigidbody2D.velocity = movement * speed;
		if(isInvisible ()){
			invisijuice -= deltaTime;
		}
		transform.rotation = Quaternion.Euler(0,0,0);
		if(timer > 0){
			timer -= deltaTime;
			if(timer <= 0)
				unSlow();
		}
		gui_text.text = "You can be invisible for " + invisijuice.ToString() + " more seconds";
		if (Vector3.Distance(transform.position, exit.transform.position) < 0.1){

		}
	}
	public override void explode(){
		Destroy(gameObject);
		Destroy (this);
	}
	public override void slow ()
	{
		speed = baseSpeed/3;
		timer = slowTime;
	}
	public bool isInvisible(){
		return !isVisible;
	}
	public void unSlow ()
	{
		speed = baseSpeed;
	}
}
