using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnVideoEnd : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;
    public Button pauseButton;
    public Button unpauseButton;

    private bool isPaused = false;
    private bool videoFinished = false;

    void Start()
    {
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
            // Initially, disable the unpause button
            //unpauseButton.interactable = false;
        }
    }

    void PauseVideo()
    {
        isPaused = true;
        videoPlayer.Pause(); // Pause the video
        //pauseButton.interactable = false;
        //unpauseButton.interactable = true;
    }

    void UnpauseVideo()
    {
        isPaused = false;
        videoPlayer.Play(); // Resume the video
        //pauseButton.interactable = true;
        //unpauseButton.interactable = false;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == videoPlayer)
        {
            videoFinished = true;
            Invoke("ChangeSceneWithDelay", 2f); // Invoke scene change after 2 seconds
        }
    }

    void ChangeSceneWithDelay()
    {
        if (videoFinished)
        {
            // Change the scene after the delay
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
