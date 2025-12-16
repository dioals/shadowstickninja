using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour 
{
	public bool IsDead = false;
	public bool forCount =false;
	public float a = 1;
	public List<GameObject> connectedbaloons = new List<GameObject>();
	void OnEnable()
	{
		a = 1;
	}
	void LateUpdate()
	{
		if (forCount) 
		{
			forCount = false;
			FindObjectOfType<GameManager> ().BadPeopleInScene -= 1;
		
		}
		if (IsDead) 
		{
			foreach (var bodypart in transform.GetComponentsInChildren<SpriteRenderer>()) 
			{
				a -= Time.deltaTime /30;		
				bodypart.color = new Color (1,1,1,a);
				if (bodypart.color.a <= 0) 
				{
					this.gameObject.SetActive (false);
					foreach (var obj in connectedbaloons) 
					{
						if (obj == null)
							return;
						Destroy (obj);
					}
				}
			}
		}
	}
}
