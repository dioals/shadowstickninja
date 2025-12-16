using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D incoming)
	{
		Debug.Log (incoming.collider.name);
		if(incoming.collider.name.Contains("Char"))
		{
			foreach (var objs in incoming.collider.GetComponents<HingeJoint2D>()) 
			{
				objs.enabled = false;
			}
			if (incoming.transform.parent.GetComponent<EnemyScript> ().IsDead)
				return;
			
			foreach(var obj in incoming.transform.parent.GetComponents<EnemyScript>())
			{
				obj.IsDead = true;
				obj.forCount= true;
			}
		}
		if (incoming.collider.name.Contains ("TNT")) 
		{			
			incoming.transform.GetComponent<TNTScript> ().Explode =true;
		}
		if(incoming.collider.name.Contains("Allie"))
		{
			foreach (var objs in incoming.collider.GetComponents<HingeJoint2D>()) 
			{
				objs.enabled = false;
			}
		
			FindObjectOfType<GameManager> ().BaloonOfLevel = 0;
			FindObjectOfType<GameManager> ().BombOfLevel = 0;
			FindObjectOfType<GameManager> ().KnifeOfLevel = 0;
			FindObjectOfType<GameManager> ().GameOver = true;
		}

	}
}
