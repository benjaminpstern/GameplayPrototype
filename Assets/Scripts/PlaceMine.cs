using UnityEngine;
using System.Collections;

public class PlaceMine : MonoBehaviour {

	public float blastRadius;
	public float detonateRadius;
	public int numMines;
	public GameObject splodeables;
	public float reloadTime;
	public float armTime;
	float timer;
	void Start(){
		timer = 0;
	}
	void Update () {
		if(Input.GetKey(KeyCode.E) && numMines > 0 && timer <= 0){
			placeMine(this.transform.position);
			numMines--;
			timer = reloadTime;
		}
		if(timer > 0)
			timer-= Time.deltaTime;
	}
	void placeMine(Vector3 position){
		GameObject mineObject = new GameObject();
		mineObject.name = "Mine";
		SpriteRenderer spriterenderer = mineObject.AddComponent<SpriteRenderer>();
		Sprite sprite = Resources.Load<Sprite>("Sprite/mine");
		spriterenderer.sprite = sprite;
		Mine mineScript = mineObject.AddComponent<Mine>();
		mineScript.init(splodeables,armTime,detonateRadius,blastRadius);
		mineScript.transform.position = position;
	}
}
