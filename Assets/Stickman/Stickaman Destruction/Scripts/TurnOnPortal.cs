using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPortal : MonoBehaviour {

	public GameObject portalobj;

	void OnTriggerEnter2D(Collider2D incoming){
		if(incoming.name.Contains("Arrow")){
			portalobj.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}
