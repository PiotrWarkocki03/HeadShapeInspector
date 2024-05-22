using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnVideoEnd : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    //public string nextSceneName;
    public Button pauseButton;
    public Button unpauseButton;
    public Button restartButton;

    private bool isPaused = false;
    private bool videoFinished = false;

    public GameObject questionPanel;

    void Start()
    {
        isPaused = false;
        if (videoPlayer == null)
        {
            Debug.LogError("Video player is not assigned!");
            return;
        }

        // Subscribe to the videoPlayer's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;

        if (pauseButton != null)
        {
            // Add a listener to the pause button click event
            pauseButton.onClick.AddListener(PauseVideo);
        }

        if (unpauseButton != null)
        {
            // Add a listener to the unpause button click event
            unpauseButton.onClick.AddListener(UnpauseVideo);
            
        }

        if (restartButton != null)
        {
            // Add a listener to the restart button click event
            restartButton.onClick.AddListener(RestartVideo);
        }

        questionPanel.SetActive(false);
    }

    void PauseVideo()
    {
        isPaused = true;
        videoPlayer.Pause(); // Pause the video
        Debug.Log("Pause Button Pressed");

    }

    void UnpauseVideo()
    {
        isPaused = false;
        videoPlayer.Play(); // Resume the video
        Debug.Log("Unpause Button Pressed");

    }

    void RestartVideo()
    {
        videoFinished = false;
        videoPlayer.Stop(); // Stop the video
        videoPlayer.Play(); // Play the video from the beginning
        questionPanel.SetActive(false);
        Debug.Log("Restart Button Pressed");
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == videoPlayer)
        {
            videoFinished = true;
            questionPanel.SetActive(true);

            
        }
    }

    
}
