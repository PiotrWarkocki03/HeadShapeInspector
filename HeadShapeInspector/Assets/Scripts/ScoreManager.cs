using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    public int totalStars; // Total stars available in each level
    public int starsEarned; // Stars earned by the player in the current level

    // Method to call when the player answers a question correctly
    public void CorrectAnswer()
    {
        starsEarned++; // Increment stars earned
        UpdateStars(); // Update UI to reflect stars earned
    }

    // Method to call when the player avoids using hints
    public void NotUsingHints()
    {
        starsEarned++; // Increment stars earned
        UpdateStars(); // Update UI to reflect stars earned
    }

    // Method to call when the player answers within the designated time frame
    public void AnswerWithinTimeFrame()
    {
        starsEarned++; // Increment stars earned
        UpdateStars(); // Update UI to reflect stars earned
    }

    // Method to update the UI to reflect stars earned
    void UpdateStars()
    {
        // Update UI to show stars earned out of total stars
        // This could be updating a UI element that displays stars earned
    }

    // Method to save stars earned in a separate scene
    public void SaveStars()
    {
        // Save starsEarned using PlayerPrefs or another persistent storage method
        // Example: PlayerPrefs.SetInt("StarsEarned", starsEarned);
    }
}
