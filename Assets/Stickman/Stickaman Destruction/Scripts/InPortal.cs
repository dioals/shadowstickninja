using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InPortal : MonoBehaviour
{
	public GameObject Arrowprefab;
	public Transform NewPos;
	public GameObject OutPortalObj;	
	
	void OnTriggerEnter2D(Collider2D incoming)
	{
		if (incoming.name.Contains("Arrow"))
		{
			Destroy(incoming.gameObject);
			if(!OutPortalObj.activeSelf)
			{
				Thisshoot();
			}else{
				FindObjectOfType<OutPortal>().ShootArrow();
			}
			
		
		}
	
	}
	public  void AShootArrow()
	{
	Instantiate (Arrowprefab,this.NewPos.position,transform.rotation);
		
	}
	public  void Thisshoot()
	{
	 Instantiate (Arrowprefab,this.NewPos.position,transform.rotation);
		
	}
}
