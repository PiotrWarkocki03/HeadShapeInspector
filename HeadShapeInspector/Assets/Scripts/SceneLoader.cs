using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Public function to be called when the button is pressed
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
