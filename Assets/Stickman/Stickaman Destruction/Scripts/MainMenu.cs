using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
	public GameObject MenuUi;
	public GameObject LevelSelectionUi;
	public GameObject ExitUI;
	public GameObject Loading;
	// Use this for initialization
	[Header("ForAnims")]
	public GameObject MenuPlayButton;
	public GameObject Title;
	void Awake () 
	{
      //  Advertisements.Instance.Initialize();
        
        MenuUi.SetActive (true);
		ExitUI.SetActive (false);
		Loading.SetActive (false);
		LevelSelectionUi.SetActive (false);
	}
	void OnEnable()
	{
		
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			PlayerPrefs.DeleteAll ();
		}
			
	}

	public void PlayButton()
	{
		MenuUi.SetActive (false);
		LevelSelectionUi.SetActive(true);
        //AdMobManager._AdMobInstance.showInterstitial ();
       // Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM);
    }
	public void ShopButton(){
		MenuUi.SetActive (false);	
	}
	public void MoreButton(){
		Application.OpenURL ("https://play.google.com/store/apps/dev?id=5581886918361803159&hl=en");
	}
	public void ExitButton(){
		ExitUI.SetActive (true);
		MenuUi.SetActive (false);
	}
	public void ExitYes(){
		Application.Quit ();
	}
	public void ExitNo(){
		MenuUi.SetActive (true);
		ExitUI.SetActive (false);
	}
	public void ShopBackButton(){
		MenuUi.SetActive (true);
	
	}
	public void LevelBackButton(){
		MenuUi.SetActive (true);
		LevelSelectionUi.SetActive (false);
	}

}
