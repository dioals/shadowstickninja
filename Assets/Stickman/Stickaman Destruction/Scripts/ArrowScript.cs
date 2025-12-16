using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowScript : MonoBehaviour 
{
	 Rigidbody2D thisrigidbody;
	int AppleHitsCount;
	public GameObject BloodEffect;
	bool isHit;
	public	GameManager gameManager;
	public GameObject BaloonPopEffect;
	void OnEnable()
	{
		this.AppleHitsCount = 0;
		this.isHit = false;
		gameManager = FindObjectOfType<GameManager> ();
	}
	void Start()
	{
		thisrigidbody = GetComponent<Rigidbody2D>();
		thisrigidbody.AddForce (transform.right * 100,ForceMode2D.Impulse);
	}
	void OnTriggerEnter2D(Collider2D incoming)
	{

		if (incoming.name.Contains ("Obstacle")) 
		{			
			thisrigidbody.linearVelocity = Vector2.zero;
			FindObjectOfType<SoundControl>().FruitSound.Play();
			//gameManager.BadPeopleInScene -= 1;
		
			AppleHitsCount += 1;
			Destroy (incoming.gameObject);
		}
	}
	Vector3 pos;
	void lateUpdate(){
		if (isHit)
			return;
		pos = this.transform.localEulerAngles;


	}
	void OnCollisionEnter2D (Collision2D incoming)
	{		

//		if (incoming.collider.name.Contains ("Character") && incoming.contacts.Length !=0) 
//		{
//		//	FindObjectOfType<SoundControl>().RagdollHitSound.Play();
//			if (!isHit) 
//			{
//				isHit = true;
////				gameManager.KnifeOfLevel = 0;
//				for(int i =0;i<incoming.contacts.Length ; i++)
//				{
//					Instantiate (BloodEffect, incoming.contacts[i].point, Quaternion.identity);	
//				}
//				gameManager.KnifeOfLevel -= 1;
//			}
//			this.transform.parent = incoming.transform;
//			thisrigidbody.isKinematic = true;
//			thisrigidbody.simulated = false;
//			this.enabled = false;
//			Object.Destroy ((Object)this.gameObject, 2f);
//		}
//		if (incoming.collider.name.Contains ("Player") && incoming.contacts.Length !=0) 
//		{			
//			FindObjectOfType<SoundControl>().RagdollHitSound.Play();
//			gameManager.KnifeOfLevel = 0;
//			for(int i =0;i<incoming.contacts.Length ; i++)
//			{
//				Instantiate (BloodEffect, incoming.contacts[i].point, Quaternion.identity);					
//			}
//			this.transform.parent = incoming.transform;
//			thisrigidbody.isKinematic = true;
//			thisrigidbody.simulated = false;
//			this.enabled = false;
//			Object.Destroy ((Object)this.gameObject, 2f);
//		}	
		if(incoming.collider.name.Contains("Platform"))
		{
			if (isHit)
				return;
			
			this.transform.parent = incoming.transform;
		//	this.transform.localEulerAngles = pos;
			Destroy (thisrigidbody);
					isHit = true;

		}
		if(incoming.collider.name.Contains("Knife"))
		{
			if (isHit)
				return;		
			Destroy (thisrigidbody);
			this.gameObject.isStatic = true;
			isHit = true;

		}
		if(incoming.collider.name.Contains("TNT"))
		{
			if (isHit)
				return;		
			Destroy (thisrigidbody);
			incoming.transform.GetComponent<TNTScript> ().Explode = true;
			isHit = true;

		}
		if(incoming.collider.name.Contains("Wheel"))
		{
			if (isHit)
				return;
			this.transform.parent = incoming.transform;
			Destroy (thisrigidbody);
			this.enabled = false;
			Destroy (this.gameObject,2);
		}

		if(incoming.collider.name.Contains("Baloon"))
		{
			if (isHit)
				return;
			Destroy (this.gameObject);
			Destroy (incoming.gameObject);
			Instantiate (BaloonPopEffect, incoming.transform.position, Quaternion.identity);

		}
		if (incoming.collider.name.Contains ("Allie") ) 
		{			
			if (isHit)
				return;
			isHit = true;
			gameManager.GameOver = true;
			gameManager.KnifeOfLevel = 0;
			gameManager.BaloonOfLevel = 0;
			gameManager.BombOfLevel = 0;
			//thisrigidbody.velocity = Vector2.zero;
			Destroy (thisrigidbody);
			this.transform.parent = incoming.transform;
			FindObjectOfType<SoundControl> ().RagdollHitSound.Play ();
		}
		if (incoming.collider.name.Contains ("rope")) 
		{
			Destroy (incoming.transform.parent.gameObject);
			Destroy (this.gameObject);
		}
		if (incoming.collider.name.Contains ("Char") ) 
		{
			

				
			if (!isHit) 
			{				
				isHit = true;
				for(int i =0;i<incoming.contacts.Length ; i++)
				{
									Instantiate (BloodEffect, incoming.contacts[i].point, Quaternion.identity);	
					FindObjectOfType<SoundControl>().RagdollHitSound.Play();
				}
				if (incoming.transform.GetComponentInParent<EnemyScript> ().IsDead == false) 
				{					
					incoming.transform.GetComponentInParent<EnemyScript> ().IsDead = true;
					incoming.transform.GetComponentInParent<EnemyScript> ().forCount = true;
				}
				thisrigidbody.isKinematic = true;
				thisrigidbody.simulated = false;
				thisrigidbody.linearVelocity = Vector2.zero;
				this.transform.parent = incoming.transform;
				Destroy (thisrigidbody);
			}
			this.enabled = false;
			Object.Destroy ((Object)this.gameObject, 2f);
		}
	}
}
