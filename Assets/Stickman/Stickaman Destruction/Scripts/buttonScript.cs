using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour 
{
	public bool MoveSpike;
	public Vector3 movePos;
	public Transform Door;
	public Vector3 startpos;
	public Sprite image2;

	// Use this for initialization
	void Start () 
	{
		startpos = Door.transform.position;

	}
	float t;
	// Update is called once per frame
	void Update () 
	{
		if (MoveSpike) 
		{
			t += Time.deltaTime;
			Door.transform.position =  Vector3.Lerp (startpos,  movePos, t);	
		}
	}
	void OnTriggerEnter2D(Collider2D incoming)
	{
		if (incoming.name.Contains ("Char") || incoming.name.Contains("Ball")||incoming.name.Contains("Baloon")) 
		{
			MoveSpike = true;
			GetComponent<SpriteRenderer> ().sprite = image2;
		}
	}
}
