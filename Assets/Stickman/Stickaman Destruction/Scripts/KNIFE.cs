using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNIFE : MonoBehaviour
{
	public float ArrowForce = 40;
	private Rigidbody2D thisRigidbody;
	public GameObject BloodEffect;
	public GameObject TntEffect;
	public GameObject Effects;
	int AppleHitsCount;
	int isHit;
	void OnEnbale()
	{
		this.AppleHitsCount = 0;
		isHit = 0;
	}
	void Start ()
	{
		thisRigidbody = this.GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{		
		if (thisRigidbody == null)
			return;
		if (!(this.thisRigidbody.linearVelocity != Vector2.zero))
			return;
	
		Vector2 velocity = this.GetComponent<Rigidbody2D> ().linearVelocity;
		this.transform.eulerAngles = new Vector3 (0.0f, 0.0f, Mathf.Atan2 (velocity.y, velocity.x) * 57.29578f);
	}
	bool DidHit = false;
	bool iscollided= false;
	void OnCollisionEnter2D (Collision2D incoming)
	{		
		if (iscollided)
			return;
		if (incoming.collider.name.Contains ("TNT")) 
		{
//			incoming.collider.GetComponent<TNTScript> ().Explode = true;	
			Destroy (this.gameObject);
		}
		if(incoming.collider.name.Contains ("Baloon")) 
		{
			Destroy (incoming.gameObject);
		}
		if (incoming.collider.name.Contains ("TNT")) 
		{
			iscollided = true;
		}
		if (incoming.collider.name.Contains ("Stone")) 
		{
			iscollided = true;
			incoming.transform.parent = incoming.transform;
			thisRigidbody.linearVelocity = Vector3.zero;
			thisRigidbody.simulated = false;
		}
		if (incoming.collider.name.Contains ("rope")) 
		{
			iscollided = true;

			Destroy (incoming.transform.parent.gameObject);
			Destroy (this.gameObject);
		}

		if (incoming.collider.name.Contains ("Wall")) 
		{
			iscollided = true;		
			thisRigidbody.isKinematic = true;
			thisRigidbody.simulated = false;
			thisRigidbody.bodyType = RigidbodyType2D.Static;
			//this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			Object.Destroy ((Object)this.gameObject, 2f);
		} 
		if (incoming.collider.name.Contains ("Crate") ) {
			iscollided = true;
			FindObjectOfType<SoundControl>().ObjectHitSound.Play();
			if (this.isHit <=0) 
			{
				
				isHit += 1;
			}

			thisRigidbody.simulated = false;
			this.GetComponent<BoxCollider2D> ().enabled = false;
			this.transform.parent = incoming.transform;
			this.enabled = false;
			Object.Destroy ((Object)this.gameObject, 2f);
		}
		if (incoming.collider.name.Contains ("Allie")) 
		{
			FindObjectOfType<GameManager> ().GameOver = true;
			FindObjectOfType<GameManager> ().BaloonOfLevel = 0;
			FindObjectOfType<GameManager> ().KnifeOfLevel = 0;
			FindObjectOfType<GameManager> ().BombOfLevel = 0;
		}
		if (incoming.collider.name.Contains ("Char"))
		{
			if (!DidHit) 
			{
				iscollided = true;
				DidHit = true;
				this.transform.parent = incoming.transform;
				thisRigidbody.isKinematic = true;
				thisRigidbody.simulated = false;
				Destroy (thisRigidbody);
				if (incoming.transform.parent.GetComponent<EnemyScript> ().IsDead)
					return;
				FindObjectOfType<SoundControl> ().RagdollHitSound.Play ();

				this.enabled = false;
				incoming.transform.parent.GetComponent<EnemyScript> ().IsDead = true;
				incoming.transform.parent.GetComponent<EnemyScript> ().forCount = true;
				if (isHit <= 0) 
				{				
					for (int i = 0; i < incoming.contacts.Length; i++) 
					{
						Instantiate (BloodEffect, incoming.contacts [i].point, Quaternion.identity);	
					}
				}
				foreach (var obj in incoming.collider.GetComponents<HingeJoint2D>()) 
				{
					obj.enabled = false;
				}
			}
		}
	}
}
