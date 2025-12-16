using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour 
{
	public GameObject Arrowprefab;
	GameManager gameManager;
	void OnEnable()
	{
		gameManager = FindObjectOfType<GameManager> ();
	}
	void OnTriggerEnter2D(Collider2D incoming)
	{
		FindObjectOfType<SoundControl>().ShootSound.Play();
		if (incoming.name.Contains ("Arrow")) {
			Destroy (incoming.gameObject);
			gameManager.KnifeOfLevel -= 1;
		 Instantiate (Arrowprefab,this.transform.position,transform.rotation);		
			Destroy (this.gameObject);
		}
	}
}
