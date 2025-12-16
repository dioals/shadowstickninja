using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBaloon : MonoBehaviour 
{
	public bool Move = false;
	void Start () 
	{
		Move = false;
		MoveThis ();
	}
	public Vector2 moveDirection;
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			MoveThis ();
		}	
	}
	void MoveThis () 
	{
		GetComponent<Rigidbody2D> ().AddForce (moveDirection * 50);
	}

}
