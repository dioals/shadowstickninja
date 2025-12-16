using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "SaveData", order = 1)]
public class MyScriptableObjectClass : ScriptableObject
{
    public string objectName = "GameData";
	public LevelData[] Levels;
}
[System.Serializable]
public class LevelData
{
	public int KnifeForLevel;
	public int BaloonForLevel;
	public int BombForLevel;
	public string Info;
}