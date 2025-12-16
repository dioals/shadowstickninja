using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour 
{
	HingeJoint2D thisHingeJoint;
	[SerializeField]
	LineRenderer thisLinerenderer;
	[SerializeField]
	SpriteRenderer ThisSpriterend;
	float t;
	bool Collided = false;
	[SerializeField]
	Sprite baloonSprite;
	[SerializeField]
	PolygonCollider2D thisCollider;
	[SerializeField]
	CircleCollider2D thisCircleCollider;
	public Transform ChildObj;
	void Start () 
	{
		transform.name = "Bomb";
		thisHingeJoint = GetComponent<HingeJoint2D> ();	

		thisHingeJoint.enabled = false;
		this.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
	}
	Transform holder;
	void OnCollisionEnter2D(Collision2D incoming)
	{	
		if (incoming.collider.name.Contains ("Char") || incoming.collider.name.Contains("Crate") || incoming.collider.name.Contains("Allie")) 
		{
			ContactPoint2D incomingcontact = incoming.contacts [0];
			transform.name= "Baloon";
			if (ThisSpriterend != null) {
				ThisSpriterend.sprite = baloonSprite;
			}
			thisCircleCollider.enabled = false;

			if (this.Collided)
				return;
			this.Collided = true;
			thisHingeJoint.enabled = true;
			thisCollider.enabled = true;
			holder = Instantiate (ChildObj, incomingcontact.point, Quaternion.identity);
			holder.transform.parent = incoming.transform;
			GetComponent<Rigidbody2D> ().gravityScale = -0.8f;		
			GetComponent<Rigidbody2D> ().AddForce(Vector2.up * 100);
			thisHingeJoint.connectedBody = incoming.collider.transform.GetComponent<Rigidbody2D> ();
			thisHingeJoint.connectedAnchor = new Vector2 (incomingcontact.point.x, incomingcontact.point.y); //(incoming.contacts[0].point.x,incoming.contacts[0].point.y);
			thisHingeJoint.anchor = new Vector2 (incoming.contacts [0].point.x, incoming.contacts [0].point.y);

			GetComponent<Rigidbody2D> ().linearVelocity = Vector3.zero;
		}	
		if (incoming.collider.name.Contains ("Spike")) 
		{
			Destroy (this.gameObject);
		}
	}

	void Update()
	{
		if (Collided) 
		{
			thisLinerenderer.SetPosition (0, this.transform.localPosition);
			thisLinerenderer.SetPosition (1, holder.position);

			t += Time.deltaTime;
			transform.localScale = Vector3.Lerp (transform.localScale,Vector3.one,t);
		}
	}
}
