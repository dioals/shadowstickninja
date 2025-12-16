using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum XTransform{
	Sin,
	Cos,
	Tan,
	simple
}
public enum Ytransform{
	Sin,
	Cos,
	Tan,
	simple
}
public enum Ztransform{
	Sin,
	Cos,
	Tan,
	simple
}
public class Movement : MonoBehaviour 
{
	public XTransform xtrans;
	public float XMove;
	public float XFreq;
	public Ytransform ytrans;
	public float YMove;
	public float YFreq;
	public Ztransform ztrans;
	public float ZMove;	
	public float ZFreq;
	public Vector3 MovementFrequency;
	Vector3 Moveposition;
	Vector3 startPosition;
	void Update () 
	{
		if (xtrans == XTransform.Sin) {
			Moveposition.x = startPosition.x + Mathf.Sin(Time.timeSinceLevelLoad * XFreq) * XMove;	
		}
		if (xtrans == XTransform.Cos) {
			Moveposition.x = startPosition.x + Mathf.Cos(Time.timeSinceLevelLoad * XFreq) * XMove;	
		}
		if (xtrans == XTransform.Tan) {
			Moveposition.x = startPosition.x + Mathf.Tan(Time.timeSinceLevelLoad * XFreq) * XMove;	
		}

		if (ytrans == Ytransform.Sin) {
			Moveposition.y = startPosition.x + Mathf.Sin(Time.timeSinceLevelLoad * YFreq) * YMove;	
		}
		if (ytrans == Ytransform.Cos) {
			Moveposition.y = startPosition.x + Mathf.Cos(Time.timeSinceLevelLoad * YFreq) * YMove;	
		}
		if (ytrans == Ytransform.Tan) {
			Moveposition.y = startPosition.x + Mathf.Tan(Time.timeSinceLevelLoad * YFreq) * YMove;	
		}
		if (ztrans == Ztransform.Sin) {
			Moveposition.z = startPosition.x + Mathf.Sin(Time.timeSinceLevelLoad * ZFreq) * ZMove;	
		}
		if (ztrans == Ztransform.Cos) {
			Moveposition.z = startPosition.x + Mathf.Cos(Time.timeSinceLevelLoad * ZFreq) * ZMove;	
		}
		if (ztrans == Ztransform.Tan) {
			Moveposition.z = startPosition.x + Mathf.Tan(Time.timeSinceLevelLoad * ZFreq) * ZMove;	
		}
		transform.localPosition = new Vector3(Moveposition.x, Moveposition.y, Moveposition.z);
	}
}
