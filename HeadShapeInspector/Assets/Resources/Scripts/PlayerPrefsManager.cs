using UnityEngine;
using UnityEngine.UI;

// Clears all saved PlayerPrefs data when called, ensuring a clean slate for player preferences.
public class PlayerPrefsManager : MonoBehaviour
{
    public void ClearAllPlayerPrefs()
    {
        //when this method is called all saved playerprefs get deleted and saved
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}

