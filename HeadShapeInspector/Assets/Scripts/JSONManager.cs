using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public string levelNumber;
    public int score;
}

[System.Serializable]
public class GameData
{
    public List<LevelData> levelsData = new List<LevelData>();
}


public class JSONManager : MonoBehaviour
{

    [ContextMenu("SaveGameData")]
    public void SaveGameData(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        SaveSystem.Save(json);
    }


    [ContextMenu("LoadGameData")]
    public GameData LoadGameData()
    {
        string saveString = SaveSystem.Load();
        if (saveString != null)
        {
            return JsonUtility.FromJson<GameData>(saveString);
        }
        else
        {
            Debug.LogWarning("File not found...");
            return null;
        }
    }



}
