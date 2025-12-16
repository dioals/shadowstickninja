using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBody : MonoBehaviour
{
	public Rigidbody2D[] bodypart;
	
	void OnEnable()
	{	
		foreach(var item in bodypart)
		{
			item.bodyType =RigidbodyType2D.Static;
		}
	}
	public void ActivateRigidbody()
	{
		foreach(var item in bodypart)
		{
		item.bodyType =RigidbodyType2D.Dynamic;
		}
	}
}
