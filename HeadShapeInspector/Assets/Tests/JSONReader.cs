using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    //reference to Json File
    public TextAsset textJSON;
    
    [System.Serializable]
    public class Difficulties
    {
        public string mode;
        public int level;
        public int starsAmount;
    }

    [System.Serializable]
    public class Difficulties1List
    {
        //array of all the levels inside the difficulty
        public Difficulties[] difficulties;
        
    }
    //intance of class
    public Difficulties1List myDifficultiesList = new Difficulties1List();
    
    
    
   
     // Start is called before the first frame update
    void Start()
    {
        //
        myDifficultiesList = JsonUtility.FromJson<Difficulties1List>(textJSON.text);

    }

   
}
