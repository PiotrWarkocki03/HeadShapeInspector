using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsManager : MonoBehaviour
{
    public void ClearAllPlayerPrefs()
    {
        //when this method is called all saved playerprefs get deleted and saved
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}

