using UnityEngine;
using System.Collections;

public class PlacePushMine : PlaceMine<PushMine> {
	void Start(){
		sprite = Resources.Load<Sprite>("Sprite/push");
	}
}
