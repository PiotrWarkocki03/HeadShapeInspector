using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        //find objects with each tag
        GameObject[] mainObject1 = GameObject.FindGameObjectsWithTag("MainCamera");
        GameObject[] mainObject2 = GameObject.FindGameObjectsWithTag("JsonManager");
        GameObject[] mainObject3 = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        GameObject[] mainObject4 = GameObject.FindGameObjectsWithTag("D1");


        // Check if there is more than one instance of mainObject1 in the scene
        if (mainObject1.Length > 1 )
        {
             // If there is, destroy this game object to ensure only one instance exists
             Destroy(this.gameObject);
        }
        // Mark this game object to not be destroyed when loading a new scene
        DontDestroyOnLoad(this.gameObject);

        // Check if there is more than one instance of mainObject2 in the scene
        if (mainObject2.Length > 1)
        {
            // If there is, destroy this game object to ensure only one instance exists
            Destroy(this.gameObject);
        }
        // Mark this game object to not be destroyed when loading a new scene
        DontDestroyOnLoad(this.gameObject);


        // Check if there is more than one instance of mainObject3 in the scene
        if (mainObject3.Length > 1)
        {
            // If there is, destroy this game object to ensure only one instance exists
            Destroy(this.gameObject);
        }
        // Mark this game object to not be destroyed when loading a new scene
        DontDestroyOnLoad(this.gameObject);

        if (mainObject4.Length > 1)
        {
            // If there is, destroy this game object to ensure only one instance exists
            Destroy(this.gameObject);
        }
        // Mark this game object to not be destroyed when loading a new scene
        DontDestroyOnLoad(this.gameObject);
    }
}
