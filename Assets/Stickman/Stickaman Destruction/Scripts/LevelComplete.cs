using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelComplete : MonoBehaviour {

	void OnEnable()
	{
		PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name,1);		
	}
	

}
