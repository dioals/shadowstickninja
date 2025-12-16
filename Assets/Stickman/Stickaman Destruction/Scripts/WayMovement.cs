using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayMovement : MonoBehaviour {
	public float speed = 5;
	private Transform target;

	public int waypointindex = 0;
	// Use this for initialization
	void Start () {
		target = WayPoints.points [0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position -= transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, target.position) <= 0.3f) {
			Nextpoint ();
		}
	}
	void Nextpoint(){
		if (waypointindex >= WayPoints.points.Length) {
			waypointindex = 0;		
		} else {
			waypointindex++;
		}

		target = WayPoints.points [waypointindex];
	}
}
