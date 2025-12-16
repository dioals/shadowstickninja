using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour {

	GameManager gameManger;
	void OnEnable()
	{
		gameManger = FindObjectOfType<GameManager> ();	
	}
	void OnTriggerEnter2D(Collider2D incoming)
	{
		if (incoming.name.Contains ("Char")) 
		{
			
			if (incoming.transform.GetComponentInParent<EnemyScript> ().IsDead == false) 
			{
				incoming.transform.GetComponentInParent<EnemyScript> ().IsDead = true;	
				incoming.transform.GetComponentInParent<EnemyScript> ().forCount = true;
			}
		}
		if (incoming.name.Contains ("Allie")) 
		{
			gameManger.KnifeOfLevel = 0;
			gameManger.BaloonOfLevel = 0;
			gameManger.BombOfLevel = 0;
			gameManger.GameOver = true;
		}
	}
}
