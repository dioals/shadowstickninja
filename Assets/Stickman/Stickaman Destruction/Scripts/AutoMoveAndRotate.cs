using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveAndRotate : MonoBehaviour {

	public Vector3 Speed;


	void Update () {
		this.transform.Rotate (Speed.x * Time.deltaTime,Speed.y * Time.deltaTime , Speed.z * Time.deltaTime);	
	}
}
