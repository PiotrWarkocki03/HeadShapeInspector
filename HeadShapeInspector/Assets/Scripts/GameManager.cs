using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private JSONManager jsonManager;
    public GameData gameData;

    [SerializeField] private string levelNumberLOCAL = "1.1";
    [SerializeField] private int scoreLOCAL = -0;


    private void Awake()
    {
        jsonManager = GetComponent<JSONManager>();
        gameData = jsonManager.LoadGameData();
    }


    [ContextMenu("GetScoreForLevel")]
    public void GetScoreForLevel()
    {
        LevelData tempLevel = gameData.levelsData.Find(data => data.levelNumber == levelNumberLOCAL);

        int i = tempLevel != null ? tempLevel.score : -1; 

        Debug.Log("1.1 score: " + i.ToString());

    }


    [ContextMenu("SaveScoreForLevel")]
    public void SaveScoreForLevel()
    {

        LevelData tempLevel = gameData.levelsData.Find(data => data.levelNumber == levelNumberLOCAL);

        if (tempLevel != null)
        {
            tempLevel.score = scoreLOCAL;
        }
        else
        {
            tempLevel = new LevelData { levelNumber = levelNumberLOCAL, score = scoreLOCAL };
            gameData.levelsData.Add(tempLevel);
        }

        jsonManager.SaveGameData(gameData);
    }



    public void SaveScoreForLevelS(string levelNumber, int score)
    {
        LevelData levelData = gameData.levelsData.Find(data => data.levelNumber == levelNumber);
        if (levelData != null)
        {
            levelData.score = score;
        }
        else
        {
            levelData = new LevelData { levelNumber = levelNumber, score = score };
            gameData.levelsData.Add(levelData);
        }

        jsonManager.SaveGameData(gameData);
    }

    public int GetScoreForLevelS(string levelNumber)
    {
        LevelData levelData = gameData.levelsData.Find(data => data.levelNumber == levelNumber);
        return levelData != null ? levelData.score : -1; // Retorna -1 se não encontrar a pontuação para o nível
    }
}
