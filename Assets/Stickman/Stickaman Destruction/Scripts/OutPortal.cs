using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutPortal : MonoBehaviour
{
	public GameObject ArrowPrefab;
	public Transform NewPos;
	public GameObject InPortalObj;
	public  void ShootArrow()
	{
	  Instantiate (ArrowPrefab,this.NewPos.position,transform.rotation);		
	}

	void OnTriggerEnter2D(Collider2D incoming)
	{
		if (incoming.name.Contains("Arrow"))
		{
			Destroy(incoming.gameObject);
			if(!InPortalObj.activeSelf)
			{
	thisshoot();
			}	
			else
			{	
				FindObjectOfType<InPortal>().AShootArrow();
			}
		}
	}
	
	void thisshoot(){
 Instantiate (ArrowPrefab,this.NewPos.position,transform.rotation);
	}

}
