// Decompiled with JetBrains decompiler
// Type: TNTScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 28631A8E-A08C-4EB7-9F3A-6C76A6CA7E74
// Assembly location: C:\Users\Day Dreamz Studio\Downloads\Stickman Destruction Warrior 2_apkpure.com\assets\bin\Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TNTScript : MonoBehaviour
{
	[SerializeField]
	private PointEffector2D thisPointEffecter;
	[SerializeField]
	private PolygonCollider2D tntCollider;
	[SerializeField]
	private CircleCollider2D explosionRadiusCollider;
	public bool Explode;
	public GameObject ExplosionEffect;
	[SerializeField]
	private CircleCollider2D detectother;

	private void Update()
	{
		if (!this.Explode)
			return;
		this.tntCollider.enabled = false;
		this.explosionRadiusCollider.enabled = true;
		this.thisPointEffecter.enabled = true;
		for(int i =0 ;i<1 ;i++)
		{
			i++;
			Object.Instantiate<GameObject>(this.ExplosionEffect, this.transform.position, Quaternion.identity);
		}

		this.GetComponent<SpriteRenderer>().enabled = false;
		this.detectother.enabled = true;
		Object.Destroy((Object) this.gameObject, 0.05f);
		Object.FindObjectOfType<SoundControl>().ExplosionSound.Play();
	}

	private void OnCollisionEnter2D(Collision2D incoming)
	{
		if (!incoming.collider.name.Contains("Spike"))
			return;
		this.Explode = true;
	}

	private void OnTriggerEnter2D(Collider2D incoming)
	{
		Debug.Log((object) incoming.name);
		if (incoming.name.Contains("TNT"))
		{
			foreach (TNTScript component in incoming.GetComponents<TNTScript>())
				component.Explode = true;
		}
		if (incoming.name.Contains("Bomb"))
		{
			foreach (BombScript component in incoming.GetComponents<BombScript>())
			{
				if ((Object) component == (Object) null)
					return;
				component.DelayTime = 0.0f;
			}
		}
		if (incoming.name.Contains("Char"))
		{
			if (incoming.transform.parent.GetComponent<EnemyScript> ().IsDead)
				return;
			foreach (Behaviour component in incoming.GetComponents<HingeJoint2D>())
				component.enabled = false;
			foreach (EnemyScript component in incoming.transform.parent.GetComponents<EnemyScript>())
			{
				component.IsDead = true;
				component.forCount = true;
			}
		}
		if (!incoming.name.Contains("Allie"))
			return;
		foreach (Behaviour component in incoming.GetComponents<HingeJoint2D>())
			component.enabled = false;
		Object.FindObjectOfType<GameManager>().BaloonOfLevel = 0;
		Object.FindObjectOfType<GameManager>().BombOfLevel = 0;
		Object.FindObjectOfType<GameManager>().KnifeOfLevel = 0;
	}
}
