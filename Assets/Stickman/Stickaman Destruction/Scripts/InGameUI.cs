using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class InGameUI : MonoBehaviour 
{
	public Text LevelNO;
	public GameObject LevelModeHUD;
	public GameObject GameOverUi;
	public GameObject GameWonUi;
	public GameObject PauseUi;
	public Text ScoreText;
	public Text KnifeCount, BaloonCount, BombCount;
	GameManager gameManager;
	void Awake()
	{
		LevelModeHUD.SetActive (true);
		GameOverUi.SetActive (false);
		PauseUi.SetActive (false);
		GameWonUi.SetActive (false);
		gameManager = FindObjectOfType<GameManager> ();
	}
	void Start()
	{
		if (gameManager.KnifeOfLevel >0) 
		{
			ArrowButton ();
		}
		else if(gameManager.BombOfLevel > 0)
		{
			BombButton ();
		}
		else if(gameManager.BaloonOfLevel >0)
		{
			BaloonButton ();
		}

	}
	float x = 1;
	void Update () 
	{	
		KnifeCount.text = gameManager.KnifeOfLevel.ToString();
		BombCount.text  = gameManager.BombOfLevel.ToString();
		BaloonCount.text = gameManager.BaloonOfLevel.ToString();

		if(x <0.1f)
		{
			x = 0;
		}
		x =Mathf.Lerp(x,0,Time.deltaTime);
		LevelNO.color = new Color(1,1,1,x);		
		
		LevelNO.text = SceneManager.GetActiveScene().buildIndex.ToString();
		ScoreText.text = gameManager.BadPeopleInScene.ToString ();

		if (gameManager.KnifeOfLevel == 0 && gameManager.BaloonOfLevel == 0 && gameManager.BombOfLevel == 0 && gameManager.bombs.Count == 0) 
		{	
			
			Debug.Log (gameManager.GameOver + "  " + gameManager.KnifeOfLevel + "  " + gameManager.BadPeopleInScene);
				

			Invoke ("Gameover", 2);

           


        }
        if (!gameManager.GameOver && gameManager.BadPeopleInScene <= 0 && !GameWonUi.activeSelf) 
		{
			if (GameOverUi.activeSelf)
				return;
					Invoke ("Active", 1);
		}

	}
	public void PauseButton()
	{
		
		Time.timeScale = 0;
		LevelModeHUD.SetActive (false);
		PauseUi.SetActive (true);

			
	}
	public void HomeButton()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenu");

	}
	public void Resume()
	{
		Time.timeScale = 1;
		LevelModeHUD.SetActive (true);
		PauseUi.SetActive (false);
	}

	public void Restart()
	{
		Time.timeScale =1;
		
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);


	}

    public void ShoInterstitiall()
    {
       // Advertisements.Instance.ShowInterstitial();

    }

	void Active()
	{
		if (GameWonUi.activeSelf)
			return;
		GameWonUi.SetActive (true);	
		gameManager.gamewin = true;
		if (AdController.instance != null)
		{
			AdController.instance.OnGameEnded();
		}

	
	}
	public void SkupLevel()
	{
		SaveSystem.SetInt(SceneManager.GetActiveScene().name, 1);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		SaveSystem.SetInt("Next", SaveSystem.GetInt("Next") + 1);
		if (SaveSystem.GetInt("Next") == 2)
		{

			SaveSystem.SetInt("Next", 0);
		}
		Time.timeScale = 1.0f;
	}
	void Gameover()
	{
		if (gameManager.BadPeopleInScene > 0) 
		{
			if (GameOverUi.activeSelf)
				return;
			GameOverUi.SetActive (true);
			SaveSystem.SetInt ("Fail",SaveSystem.GetInt("Fail")+1);
			if (SaveSystem.GetInt ("Fail") == 2) {
	
				SaveSystem.SetInt ("Fail", 0);
			}
			gameManager.GameOver = true;
			if (AdController.instance != null)
			{
				AdController.instance.OnGameEnded();
			}


		
		} 
		else 
		{
			Active ();
		}			
	}
	public GameObject selectedknife,selectedbaloon,selectedbomb;
	public void BaloonButton()
	{
		gameManager.IsKnife = false;
		gameManager.IsBomb = false;
		gameManager.IsBaloon = true;
		selectedknife.SetActive (false);
		selectedbomb.SetActive (false);
		selectedbaloon.SetActive (true);
	}
	public void ArrowButton()
	{
		gameManager.IsKnife = true;
		gameManager.IsBomb = false;
		gameManager.IsBaloon = false;
		selectedknife.SetActive (true);
		selectedbomb.SetActive (false);
		selectedbaloon.SetActive (false);
	}
	public void BombButton() 
	{
		gameManager.IsKnife = false;
		gameManager.IsBomb = true;
		gameManager.IsBaloon = false;
		selectedknife.SetActive (false);
		selectedbomb.SetActive (true);
		selectedbaloon.SetActive (false);
	}
	public void NextLevel()
	{
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene().buildIndex +1);
		SaveSystem.SetInt ("Next", SaveSystem.GetInt ("Next") + 1);
		if (SaveSystem.GetInt ("Next") == 2) {
		
			SaveSystem.SetInt ("Next", 0);
		}
	}
	public void Stickmancrush2(){
		
	}
	public void StickmanDestructions(){
		
	}
	public void StickmanShooter(){
	
	}

	public Image iconimg1,iconimg2;
	public void OpenUrl(){
		//Application.OpenURL(GamePromoManager._GamePromoManager.LoadediconLick);
	}
}
