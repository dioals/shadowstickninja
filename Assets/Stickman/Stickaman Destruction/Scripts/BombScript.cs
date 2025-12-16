
using UnityEngine;

public class BombScript : MonoBehaviour
{
	[SerializeField]
	private PointEffector2D thisPointEffecter;
	[SerializeField]
	private CircleCollider2D tntCollider;
	[SerializeField]
	private CircleCollider2D explosionRadiusCollider;
	public bool Explode;
	public GameObject ExplosionEffect;
	[SerializeField]
	private CircleCollider2D detectother;
	private float t;
	public float DelayTime;
	public TextMesh TimeText;
	private Rigidbody2D thisRigidBody;
	private bool isCollided;

	private void OnEnable()
	{
		this.thisRigidBody = this.GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		this.DelayTime -= Time.deltaTime;
		this.TimeText.text = Mathf.RoundToInt(this.DelayTime).ToString();
		if ((double) this.DelayTime >= 1.0)
			return;
		this.Explode = false;
		this.tntCollider.enabled = false;
		this.explosionRadiusCollider.enabled = true;
		this.thisPointEffecter.enabled = true;
		Object.Instantiate<GameObject>(this.ExplosionEffect, this.transform.position, Quaternion.identity);
		this.GetComponent<SpriteRenderer>().enabled = false;
		this.detectother.enabled = true;
		Object.FindObjectOfType<SoundControl>().ExplosionSound.Play();
		Object.Destroy((Object) this.gameObject, 0.05f);
	}

	private void OnDestroy()
	{
		FindObjectOfType<GameManager>().bombs.RemoveAt(0);
	}

	private void OnTriggerEnter2D(Collider2D incoming)
	{
		Debug.Log((object) incoming.name);
		if (incoming.name.Contains("TNT"))
		{
			foreach (TNTScript component in incoming.GetComponents<TNTScript>())
				component.Explode = true;
		}
		if (!incoming.name.Contains("Char") && !incoming.name.Contains("Allie"))
			return;
		foreach (Behaviour component in incoming.GetComponents<HingeJoint2D>())
			component.enabled = false;
		if (incoming.transform.parent.GetComponent<EnemyScript>().IsDead)
			return;
		incoming.transform.parent.GetComponent<EnemyScript>().IsDead = true;
		incoming.transform.parent.GetComponent<EnemyScript>().forCount = true;
	}

	private void OnCollisionEnter2D(Collision2D incoming)
	{
		if (incoming.collider.name.Contains("Allie"))
		{

			FindObjectOfType<GameManager> ().KnifeOfLevel = 0;
			FindObjectOfType<GameManager> ().BombOfLevel = 0;
			FindObjectOfType<GameManager> ().BaloonOfLevel = 0;
			FindObjectOfType<GameManager> ().GameOver = true;
			Object.FindObjectOfType<SoundControl>().RagdollHitSound.Play();
		}
	
		if (incoming.collider.name.Contains ("Char") )
		{		
			if (incoming.collider.transform.parent.GetComponent<EnemyScript> ().IsDead)
				return;
			
			
		this.isCollided = true;
		this.thisRigidBody.linearVelocity = (Vector2) Vector3.one;
		this.transform.parent = incoming.transform;
		Object.Destroy((Object) this.thisRigidBody);
			Object.FindObjectOfType<SoundControl>().RagdollHitSound.Play();
	
		}

	}
}
