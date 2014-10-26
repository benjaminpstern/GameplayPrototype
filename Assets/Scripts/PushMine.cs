using UnityEngine;
using System.Collections;

public class PushMine : Mine {
	public float magnitude = 200000;
	public void init(GameObject blowupables, float armTime,float detRad, float blastRad, float mag){
		base.init(blowupables, armTime, detRad, blastRad);
		this.magnitude = mag;
	}
	public override void activate(Splodeable s){
		Vector3 r = s.transform.position - this.transform.position;
		s.push(r.normalized * magnitude);
	}
}
