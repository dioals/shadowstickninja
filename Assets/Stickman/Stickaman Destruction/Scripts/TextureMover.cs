using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMover : MonoBehaviour {

	public Material thimat;
	public Vector2 Speed;
	
	// Update is called once per frame
	void Update () {
		thimat.SetTextureOffset ("_MainTex", new Vector2( Time.time / Speed.x, 0));
	}
}

