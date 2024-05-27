using System;
using System.Collections.Generic;
using UnityEngine;


//// Manages game data and provides methods to retrieve and save scores for different levels.
[System.Serializable]
public class GameManager : MonoBehaviour
{
    public JSONManager jsonManager;
    public GameData gameData;

    private void Awake()
    {
        jsonManager = GetComponent<JSONManager>();
        gameData = jsonManager.LoadGameData();
    }

    public int GetScoreForLevel(string l = "0")
    {
        LevelData tempLevel = gameData.levelsData.Find(data => data.levelNumber == l);

        int i = tempLevel != null ? tempLevel.levelScore : -333; // Returns -333 if it doesn't find the level at all

        return (i);
    }

    public void SaveScoreForLevel(string l, int score)
    {

        LevelData tempLevel = gameData.levelsData.Find(data => data.levelNumber == l);

        if (tempLevel != null)
        {
            tempLevel.levelScore = score;
        }
        else
        {
            tempLevel = new LevelData { levelNumber = l, levelScore = score };
            gameData.levelsData.Add(tempLevel);
        }

        jsonManager.SaveGameData(gameData);
    }


}
