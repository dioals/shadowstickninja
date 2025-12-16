using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class GameManager : MonoBehaviour 
{	
	public int KnifeOfLevel;
	public bool GameOver;
	public bool IsBaloon;
	public bool IsBomb;
	public bool IsKnife;
	public int BombOfLevel;
	public int BaloonOfLevel;
	public GameObject InGameUiPrefab;
	public GameObject SoundControllerPrefab;
	public int BadPeopleInScene;
	public MyScriptableObjectClass levelData;
	public bool gamewin;
	[SerializeField]
	private Sprite[] bgSprites;
	[SerializeField]
	private SpriteRenderer BgImages;
	public List<BombScript> bombs = new List<BombScript>();
	void OnEnable()
	{
		Analytics.CustomEvent(SceneManager.GetActiveScene().name);

		BgImages.sprite = bgSprites [Random.Range (0, bgSprites.Length)];
		if (FindObjectOfType<InGameUI> () == null) 
		{
			Instantiate (InGameUiPrefab);
		} 
		else
		{
			Destroy (FindObjectOfType<InGameUI>().gameObject);
			Instantiate (InGameUiPrefab);
		}
		if (FindObjectOfType<SoundControl> () == null) 
		{
			Instantiate (SoundControllerPrefab);
		} 
		else
		{
			Destroy (FindObjectOfType<SoundControl>().gameObject);
			Instantiate (SoundControllerPrefab);
		}
		KnifeOfLevel = levelData.Levels [SceneManager.GetActiveScene ().buildIndex].KnifeForLevel;
		BombOfLevel = levelData.Levels [SceneManager.GetActiveScene ().buildIndex].BombForLevel;
		BaloonOfLevel = levelData.Levels [SceneManager.GetActiveScene ().buildIndex].BaloonForLevel;
		BadPeopleInScene = FindObjectsOfType<EnemyScript> ().Length;
	}
	void Start () 
	{
		
	}
	

	void Update () 
	{
		if (BadPeopleInScene < 0) {
			BadPeopleInScene = 0;
		}
	}
}
