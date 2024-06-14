using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Manages the saving and loading of game data using JSON serialization.
[System.Serializable]
public class LevelData
{
    public string levelNumber;
    public int levelScore;
}

[System.Serializable]
public class GameData
{
    public List<LevelData> levelsData = new List<LevelData>();
}

public class JSONManager : MonoBehaviour
{
    public static string SAVE_FOLDER;
    public string FILENAME = "save.json";

    private void Awake()
    {
        // Set the save folder path in Awake
        SAVE_FOLDER = Application.persistentDataPath + "/Resources/Saves/";

        // Test if Save folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }

        Debug.Log("Save folder path: " + SAVE_FOLDER);

        // Ensure save file is created if it doesn't exist
        EnsureSaveFileExists();
    }

    private void EnsureSaveFileExists()
    {
        string filePath = Path.Combine(SAVE_FOLDER, FILENAME);

        if (!File.Exists(filePath))
        {
            Debug.Log("Save file not found. Creating new save file.");
            SaveGameData(new GameData());
        }
    }

    [ContextMenu("SaveGameData")]
    public void SaveGameData(GameData gameData)
    {
        // Convert the object to JSON
        string json = JsonUtility.ToJson(gameData);

        // Path of the file where the data will be saved
        string filePath = Path.Combine(SAVE_FOLDER, FILENAME);

        // Write the JSON to the file
        File.WriteAllText(filePath, json);
        Debug.Log("Saved data to: " + filePath);
    }

    [ContextMenu("ClearGameData")]
    public void ClearGameData()
    {
        // Create an empty GameData object
        GameData emptyGameData = new GameData();

        // Convert the object to JSON
        string json = JsonUtility.ToJson(emptyGameData);

        // Path of the file where the data will be saved
        string filePath = Path.Combine(SAVE_FOLDER, FILENAME);

        // Write the JSON to the file, overwriting any existing data
        File.WriteAllText(filePath, json);
        Debug.Log("Cleared game data.");
    }

    [ContextMenu("LoadGameData")]
    public GameData LoadGameData()
    {
        // Path of the file where the data will be saved
        string filePath = Path.Combine(SAVE_FOLDER, FILENAME);

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read the JSON from the file
            string json = File.ReadAllText(filePath);

            // Convert the JSON back to object
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Loaded data from: " + filePath);

            return gameData;
        }
        else
        {
            Debug.LogError("The file couldn't be found at: " + filePath);
            return null;
        }
    }
}
