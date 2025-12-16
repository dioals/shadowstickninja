using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour {

	void OnEnable(){
		Destroy (this.gameObject, 1);	
	}

}
