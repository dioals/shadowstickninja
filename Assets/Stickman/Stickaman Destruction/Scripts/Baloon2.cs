using UnityEngine;

public class Baloon2 : MonoBehaviour
{
	private LineRenderer thisLinerenderer;
	private float t;
	private bool Collided;
	public Sprite baloonSprite;
	public CircleCollider2D BulletCollider;
	public PolygonCollider2D BaloonCollider;
	private Collider2D incomingpt;
	private Transform incomingObjpt;
	public Transform Emptyobj;

	private void Start()
	{
		this.thisLinerenderer = this.GetComponent<LineRenderer>();
		this.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
		this.BaloonCollider.enabled = false;
		this.BulletCollider.enabled = true;
		this.transform.gameObject.name = "empty";
	}

	private void OnCollisionEnter2D(Collision2D incoming)
	{
		if (incoming.collider.name.Contains ("Spike")) 
		{
			Destroy (this.gameObject);
		}
		Debug.Log((object) incoming.collider.name);
		if (incoming.collider.name.Contains("Char") || incoming.collider.name.Contains("Crate") || (incoming.collider.name.Contains("Allie") || incoming.collider.name.Contains("TNT")) || incoming.collider.name.Contains("Ball"))
		{
			if (Collided)
				return;
			if (incoming.collider.GetComponent<DistanceJoint2D> () != null)
			{
				this.transform.gameObject.name = "Baloon";
				this.incomingObjpt = Object.Instantiate<Transform> (this.Emptyobj, (Vector3)incoming.contacts [0].point, Quaternion.identity);
				this.incomingObjpt.localScale = Vector3.one;
				this.incomingObjpt.transform.parent = incoming.collider.transform;
				incoming.collider.gameObject.AddComponent (typeof(DistanceJoint2D));

				this.GetComponent<SpriteRenderer> ().sprite = this.baloonSprite;
				this.BaloonCollider.enabled = true;
				this.BulletCollider.enabled = false;
				this.GetComponent<Rigidbody2D> ().gravityScale = -20f;
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 100f);
				this.Collided = true;
				this.GetComponent<Rigidbody2D> ().linearVelocity = (Vector2)Vector3.zero;
				foreach (var obj in incoming.collider.GetComponents<DistanceJoint2D>()) {
					obj.autoConfigureDistance = false;
					obj.distance = 2f;
					if (obj.connectedBody == null) {
						obj.anchor = new Vector2 (this.incomingObjpt.localPosition.x, this.incomingObjpt.localPosition.y);
						incoming.collider.GetComponent<DistanceJoint2D> ().autoConfigureConnectedAnchor = false;

						obj.connectedBody = this.GetComponent<Rigidbody2D> ();
					}
				}
			} 
			else 
			{
				if (this.Collided)
					return;
				this.transform.gameObject.name = "Baloon";
				this.incomingObjpt = Object.Instantiate<Transform> (this.Emptyobj, (Vector3)incoming.contacts [0].point, Quaternion.identity);
				this.incomingObjpt.localScale = Vector3.one;
				this.incomingObjpt.transform.parent = incoming.collider.transform;
				incoming.collider.gameObject.AddComponent (typeof(DistanceJoint2D));
				incoming.collider.GetComponent<DistanceJoint2D> ().autoConfigureDistance = false;
				incoming.collider.GetComponent<DistanceJoint2D> ().autoConfigureDistance = false;
				incoming.collider.GetComponent<DistanceJoint2D> ().autoConfigureDistance = false;
				incoming.collider.GetComponent<DistanceJoint2D> ().autoConfigureConnectedAnchor = false;
				incoming.collider.GetComponent<DistanceJoint2D> ().anchor = new Vector2 (this.incomingObjpt.localPosition.x, this.incomingObjpt.localPosition.y);
				incoming.collider.GetComponent<DistanceJoint2D> ().distance = 2f;
				this.GetComponent<SpriteRenderer> ().sprite = this.baloonSprite;
				this.BaloonCollider.enabled = true;
				this.BulletCollider.enabled = false;
				this.GetComponent<Rigidbody2D> ().gravityScale = -20f;
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 100f);
				this.Collided = true;
				this.GetComponent<Rigidbody2D> ().linearVelocity = (Vector2)Vector3.zero;
				incoming.collider.GetComponent<DistanceJoint2D> ().enabled = true;
				incoming.collider.GetComponent<DistanceJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();
				if (incoming.collider.name.Contains ("Char")) 
				{
					incoming.collider.GetComponentInParent<EnemyScript> ().connectedbaloons.Add(this.gameObject);
				}
			}
		}
	
	}

	private void Update()
	{
		if (!this.Collided)
			return;
		this.thisLinerenderer.SetPosition(0, this.transform.localPosition);
		this.thisLinerenderer.SetPosition(1, this.incomingObjpt.position);
		this.t += Time.deltaTime / 20f;
		this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.one, this.t);
	}
}
