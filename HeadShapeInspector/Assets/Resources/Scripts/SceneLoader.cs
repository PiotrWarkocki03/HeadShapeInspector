using UnityEngine;
using UnityEngine.SceneManagement;

// Handles scene loading functionality, including loading scenes by name and reloading the current scene.
public class SceneLoader : MonoBehaviour
{
    // Public function to be called when the button is pressed
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the scene by loading it again using its index
        SceneManager.LoadScene(currentSceneIndex);
    }


}
