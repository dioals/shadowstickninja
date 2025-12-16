using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	public Transform DoorLeft;
	public Transform DoorRight;
	public enum DoorState
	{
		Close,
		Open,
		None
	}
	public DoorState doorState;
	public Transform[] leftpos;
	public Transform[] rightpos;
	void Start () {
		
	}
	float t1,t2;
	// Update is called once per frame
	void Update () 
	{
		switch(doorState)
		{
		case DoorState.Close:
			t1 += Time.deltaTime/10;
			DoorLeft.transform.localPosition = Vector3.Lerp (DoorLeft.transform.localPosition, leftpos [0].localPosition, t1);
			DoorRight.transform.localPosition = Vector3.Lerp (DoorLeft.transform.localPosition, rightpos [0].localPosition, t1);
			if (Vector3.Distance(DoorLeft.transform.position,leftpos [0].position) <0.02f) 
			{
				doorState = DoorState.None;
			}
			break;
		case DoorState.Open:
			t2 += Time.deltaTime/10;
			DoorLeft.transform.localPosition = Vector3.Lerp (DoorLeft.transform.localPosition,leftpos[1].localPosition,t2);
			DoorRight.transform.localPosition = Vector3.Lerp (DoorLeft.transform.localPosition,rightpos[1].localPosition,t2);
			if (Vector3.Distance(DoorLeft.transform.position,leftpos [1].position) <0.02f) 
			{
				doorState = DoorState.None;
			}
			break;
		case DoorState.None:
			t1 = 0;
			t2 = 0;
			break;
		}	
	}
}
