using UnityEngine;

//Quits the game when the method is called
public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Quit the application
    }
}
