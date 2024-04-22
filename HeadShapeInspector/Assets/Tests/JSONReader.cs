using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    // string >> mode.levelNumber   int >> starsAmount
    public Dictionary<string,int> level;

    //reference to Json File
    public TextAsset textJSON;

    [ContextMenu("Load Dictionary From JSON")]
    void LoadDictionaryFromJsonFile()
    {
        Debug.Log(textJSON.text);

        // Convert the JSON string back to a dictionary
        Dictionary<string, int> loadedDictionary = JsonUtility.FromJson<Dictionary<string, int>>(textJSON.text);

        // Now you can use the loadedDictionary
        Debug.Log("Loaded dictionary:");

        Debug.Log(loadedDictionary["1.1"]);

        foreach (KeyValuePair<string, int> kvp in loadedDictionary)
        {
            Debug.Log("Key: " + kvp.Key + ", Value: " + kvp.Value);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //        myDifficultiesList = JsonUtility.FromJson<Difficulties1List>(textJSON.text);


    }

   
}
