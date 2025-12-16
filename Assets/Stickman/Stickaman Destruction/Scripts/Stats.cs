using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats : MonoBehaviour {
	public Text InfiniteScore;
	// Use this for initialization
	void Start () {
		InfiniteScore.text = SaveSystem.GetInt ("inf_Score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
