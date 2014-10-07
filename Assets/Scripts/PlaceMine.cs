using UnityEngine;
using System.Collections;

public class PlaceMine<T> : MonoBehaviour where T : Mine {

	public float blastRadius;
	public float detonateRadius;
	public int numMines;
	public GameObject splodeables;
	public KeyCode keycode = KeyCode.E;
	public float reloadTime;
	public float armTime;
	protected float timer;
	protected void Start(){
		timer = 0;
		numMines = 5;
	}
	protected void Update () {
		if(Input.GetKey(keycode) && numMines > 0 && timer <= 0){
			placeMine(this.transform.position);
			numMines--;
			timer = reloadTime;
		}
		if(timer > 0)
			timer-= Time.deltaTime;
	}
	protected void placeMine(Vector3 position){
		GameObject mineObject = new GameObject();
		mineObject.name = "Mine";
		SpriteRenderer spriterenderer = mineObject.AddComponent<SpriteRenderer>();
		Sprite sprite = Resources.Load<Sprite>("Sprite/mine");
		spriterenderer.sprite = sprite;
		T mineScript = mineObject.AddComponent<T>();
		mineScript.init(splodeables,armTime,detonateRadius,blastRadius);
		mineScript.transform.position = position;
	}
}
