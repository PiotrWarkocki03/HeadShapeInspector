using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{

    public TextAsset textJSON;
    [System.Serializable]

    public class Difficulties
    {
        public string mode;
        public int level;
        public int starsAmount;
    }

    [System.Serializable]
    public class DifficultiesList
    {
        public Difficulties[] difficulties;
    }

    public DifficultiesList myDifficultiesList = new DifficultiesList();
    
    
    
   
     // Start is called before the first frame update
    void Start()
    {
        myDifficultiesList = JsonUtility.FromJson<DifficultiesList>(textJSON.text);
    }

   
}
