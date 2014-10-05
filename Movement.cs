using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 1.0f;
	public float tilt = 1.0f;
	public Shader invis; 
	public Shader visible;
	void Start(){
		invis  = Shader.Find ("Transparent/Diffuse");
		visible = Shader.Find ("Sprites/Default");
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
			
		}if(Input.GetKey (KeyCode.Mouse0)){
			
					renderer.material.shader = visible;
				
				}
		}


}
