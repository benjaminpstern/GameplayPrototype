using UnityEngine;
using System.Collections;

public class SlowTrap : Mine {

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
							s[j].slow ();
						}
					}
					destroy();
				}
			}
		}
	}
}
