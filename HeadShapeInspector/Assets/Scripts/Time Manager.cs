using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private bool isPaused = true; // Start paused initially
    private float timer = 0f;
    public Text timerText; // Reference to the UI Text component



    void Start()
    {
        isPaused = false;
        Debug.Log("Timer started");
    }
    void Update()
    {
        if (!isPaused)
        {
            timer += Time.deltaTime;
            UpdateTimerText(); // Update the timer text
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Calculate minutes and seconds
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);

            // Update the UI Text with the timer value
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartTimer()
    {
        isPaused = false;
        Debug.Log("Timer started");
    }

    public void PauseTimer()
    {
        isPaused = true;
        Debug.Log("Timer paused");
    }

    public void UnpauseTimer()
    {
        isPaused = false;
        Debug.Log("Timer unpaused");
    }
}
