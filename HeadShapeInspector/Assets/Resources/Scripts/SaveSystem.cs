using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Provides static methods for saving and loading game data to/from a text file.
public static class SaveSystem
{

                                   //previously Application.dataPath
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/Resources/Saves/";
    public static readonly string FileName = "save.txt";
    public static void Init()
    {
        //Test if Save folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            //Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
    public static void Save(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + FileName, saveString);
    }
    public static string Load()
    {
        string filePath = Path.Combine(SAVE_FOLDER, FileName);

        if (File.Exists(filePath))
        {
            string saveString = File.ReadAllText(filePath);
            return saveString;
        }
        else
        {
            return null;
        }
    }
}
