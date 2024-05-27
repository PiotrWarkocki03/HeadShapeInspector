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

[System.Serializable]
public class JSONManager : MonoBehaviour
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Resources/Saves/";

    public string FILENAME = "save.json";


    private void Awake()
    {
        //Test if Save folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            //Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }


    [ContextMenu("SaveGameData")]
    public void SaveGameData(GameData gameData)
    {
        // Convertendo o objeto Cliente para JSON
        string json = JsonUtility.ToJson(gameData);

        // Caminho do arquivo onde os dados serão salvos
        string caminhoArquivo = Path.Combine(SAVE_FOLDER, FILENAME);

        // Escrevendo o JSON no arquivo
        File.WriteAllText(caminhoArquivo, json);
    }


    [ContextMenu("LoadGameData")]
    public GameData LoadGameData()
    {
        // Caminho do arquivo onde os dados serão salvos
        string caminhoArquivo = Path.Combine(SAVE_FOLDER, FILENAME);

        // Verificando se o arquivo existe
        if (File.Exists(caminhoArquivo))
        {
            // Lendo o JSON do arquivo
            string json = File.ReadAllText(caminhoArquivo);

            // Convertendo o JSON de volta para objeto Cliente
            GameData g = JsonUtility.FromJson<GameData>(json);

            return g;
        }
        else
        {
            Debug.LogError("The file couldn't be found.");
            return null;
        }
    }



}