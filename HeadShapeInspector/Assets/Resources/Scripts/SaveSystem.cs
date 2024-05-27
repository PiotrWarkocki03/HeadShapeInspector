using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Provides static methods for saving and loading game data to/from a text file.
public static class SaveSystem
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
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
        if (File.Exists(SAVE_FOLDER + FileName))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + FileName);
            return saveString;
        }
        else
        {
            return null;
        }
    }
}
