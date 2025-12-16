using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour 
{

	LineRenderer thisLinerenderer;
	public Transform pos;
	void OnEnable()
	{
		thisLinerenderer = GetComponent<LineRenderer> ();
	}
	void LateUpdate () 
	{
		thisLinerenderer.SetPosition (0,transform.localPosition);
		thisLinerenderer.SetPosition (1,pos.localPosition);
	}
}
