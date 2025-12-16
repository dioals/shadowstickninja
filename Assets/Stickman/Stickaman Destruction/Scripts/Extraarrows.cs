using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extraarrows : MonoBehaviour 
{
	public GameObject ArrowPrefab;
	
	void onTriggerEnter2D (Collider2D incoming) 
	{
		if (incoming.gameObject.name.Contains ("Arrow")) {
			Debug.Log ("Hey");
			Instantiate (ArrowPrefab,this.transform.position,this.transform.rotation);
			Destroy (this.gameObject);
		}

	}
}
