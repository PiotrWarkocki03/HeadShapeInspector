using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] mainObject1 = GameObject.FindGameObjectsWithTag("MainCamera");
        GameObject[] mainObject2 = GameObject.FindGameObjectsWithTag("JsonManager");
        GameObject[] mainObject3 = GameObject.FindGameObjectsWithTag("BackgroundMusic");

        if (mainObject1.Length > 1 )
        {
             Destroy(this.gameObject);  
        }
        DontDestroyOnLoad(this.gameObject);

        if (mainObject2.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        if (mainObject3.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
