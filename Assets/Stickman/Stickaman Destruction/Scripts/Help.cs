using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Help : MonoBehaviour 
{
	public string levelname;
	void OnEnable() 
	{
		
		if(SceneManager.GetActiveScene().name != levelname)
		{
			this.gameObject.SetActive (false);
		}
	}
	void Update()
	{
		if (FindObjectOfType<GameManager> ().GameOver || FindObjectOfType<GameManager> ().gamewin) 
		{
			this.gameObject.SetActive (false);
		}			

	}

	

}
