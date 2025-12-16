using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUnlock : MonoBehaviour 
{

	public GameObject PreviousLevel;
	public GameObject lockImage;
	void Start () 
	{
		
		//PlayerPrefs.SetInt (PreviousLevel.gameObject.name,1);
		if (PlayerPrefs.GetInt (PreviousLevel.gameObject.name) == 1) 
		{
			GetComponent<Button> ().interactable = true;
			lockImage.SetActive (false);
		} else {
			GetComponent<Button> ().interactable = false;
			lockImage.SetActive (true);
		}
	}
}
