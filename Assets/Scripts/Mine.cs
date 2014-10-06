using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject splodeables;
	public float blastRadius;
	public float detonateRadius;
	protected float timer;
	public void init(GameObject blowupables, float armTime,float detRad, float blastRad){
		splodeables = blowupables;
		detonateRadius = detRad;
		blastRadius = blastRad;
		timer = armTime;
	}
	
	void Update () {
		if(timer > 0){
			timer -= Time.deltaTime;
		}
		else{
			Splodeable[] s = splodeables.GetComponentsInChildren<Splodeable>();
			for(int i=0;i<s.Length;i++){
				float r = (s[i].transform.position - this.transform.position).magnitude;
				if(r <= detonateRadius){
					for(int j=0;j<s.Length;j++){
						float rj = (s[j].transform.position - this.transform.position).magnitude;
						if(rj < blastRadius){
							(s[j] as Splodeable).explode ();
						}
					}
					destroy();
				}
			}
		}
	}
	protected void destroy(){
		Destroy(gameObject);
	}
}
