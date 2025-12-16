using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class LevelScelection : MonoBehaviour 
{
	
	public GameObject Loading;
	public void InfiniteModeButton() 
	{
		SaveSystem.SetString ("LevelLoad", "InfiniteMode");
		Loading.SetActive (true);
		this.gameObject.SetActive (false);
	}

	public void LoadLevel(string level)
	{
		Analytics.CustomEvent(level);
		SceneManager.LoadScene (level);


	}

}
