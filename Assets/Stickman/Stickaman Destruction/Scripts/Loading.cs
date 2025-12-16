using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour {


	// Use this for initialization
	void OnEnable() {
        
        Invoke ("LoadScene", 2);
		Debug.Log (PlayerPrefs.GetString ("LevelLoad"));
	}
	
	// Update is called once per frame
	void LoadScene () {
		SceneManager.LoadScene (PlayerPrefs.GetString("LevelLoad"));
	}
}
