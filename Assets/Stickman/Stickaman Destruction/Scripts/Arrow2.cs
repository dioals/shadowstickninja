using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow2 : MonoBehaviour
{
	
	public float ArrowForce = 40;
	public GameObject TrailEffect;
	private Rigidbody2D thisRigidbody;

	public GameObject Effects;
	int AppleHitsCount;
	int isHit;
	GameManager gameManager;
	void OnEnbale()
	{
		this.AppleHitsCount = 0;
		isHit = 0;
		gameManager = FindObjectOfType<GameManager> ();
	}
	void Start ()
	{		
		thisRigidbody = this.GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D (Collision2D incoming)
	{	
		if (incoming.collider.name.Contains ("Wall")) 
		{
			if (isHit  <=0) {
				gameManager.KnifeOfLevel -= 1;
				isHit += 1;
			}	
			Debug.Log ("WallHit");
			thisRigidbody.isKinematic = true;
			thisRigidbody.simulated = false;
			thisRigidbody.bodyType = RigidbodyType2D.Static;	
			Object.Destroy ((Object)this.gameObject, 2f);
		} 
		if (incoming.collider.name.Contains ("Crate") ) {
			
			if (this.isHit <=0) {
				gameManager.KnifeOfLevel -= 1;
				isHit += 1;
			}
			thisRigidbody.simulated = false;
			this.GetComponent<BoxCollider2D> ().enabled = false;
			this.transform.parent = incoming.transform;
			this.enabled = false;
			Object.Destroy ((Object)this.gameObject, 2f);
		}
	}

	void OnTriggerEnter2D (Collider2D incoming)
	{
//		if (incoming.name.Contains ("Obstacle")) 
//		{	
//			FindObjectOfType<SoundControl>().FruitSound.Play();
//			AppleHitsCount += 1;
//			gameManager.BadPeopleInScene -= 1;
//			Destroy (incoming.gameObject);
//			Instantiate (Effects, incoming.transform.position, Quaternion.identity);		
//		
//			incoming.gameObject.AddComponent<Rigidbody2D> ().AddForce (Vector2.right * 700);		
//			Destroy (incoming.gameObject, 3);
//		}
	}
}
