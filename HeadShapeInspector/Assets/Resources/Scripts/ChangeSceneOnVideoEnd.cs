using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

/*Script used to  manage behaviours for the video,such as:
Pause,unpause, rewind, fastforward
Volume slider to determine the volume of the video being played,
Linked with BackgroundAudioManager to pause background audio while video is played*/
public class ChangeSceneOnVideoEnd : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button pauseToggleButton;
    public Button pauseButton;
    public Button unpauseButton;
    public Button rewindButton;
    public Button fastForwardButton;
    public Slider volumeSlider;
    public GameObject questionPanel;

    private bool isPaused = false;
    private bool videoFinished = false;
    private bool audioPausedByVideo = false;

    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("Video player is not assigned!");
            return;
        }

        videoPlayer.loopPointReached += OnVideoEnd;

        if (pauseToggleButton != null)
        {
            pauseToggleButton.onClick.AddListener(TogglePauseVideo);
        }

        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(PauseVideo);
        }

        if (unpauseButton != null)
        {
            unpauseButton.onClick.AddListener(UnpauseVideo);
        }

        if (rewindButton != null)
        {
            rewindButton.onClick.AddListener(RewindVideo);
        }

        if (fastForwardButton != null)
        {
            fastForwardButton.onClick.AddListener(FastForwardVideo);
        }

        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);
            float savedVolume = PlayerPrefs.GetFloat("VideoVolume", 0.5f); // Default volume is 0.5
            volumeSlider.value = savedVolume;
            SetVolume(savedVolume);
        }
        else
        {
            Debug.LogError("Volume slider is not assigned!");
        }

        if (questionPanel != null)
        {
            questionPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Question panel is not assigned!");
        }

        // Pause background audio when video starts
        if (BackgroundAudioManager.instance != null && BackgroundAudioManager.instance.audioSource.isPlaying)
        {
            BackgroundAudioManager.instance.PauseAudio();
            audioPausedByVideo = true;
        }
    }

    void TogglePauseVideo()
    {
        if (isPaused)
        {
            UnpauseVideo();
        }
        else
        {
            PauseVideo();
        }
    }

    void PauseVideo()
    {
        if (!isPaused)
        {
            isPaused = true;
            videoPlayer.Pause();
            Debug.Log("Pause Button Pressed");
        }
    }

    void UnpauseVideo()
    {
        if (isPaused)
        {
            isPaused = false;
            videoPlayer.Play();
            Debug.Log("Unpause Button Pressed");
        }
    }

    void RewindVideo()
    {
        if (videoPlayer != null)
        {
            double newTime = Mathf.Max((float)videoPlayer.time - 15f, 0);
            videoPlayer.time = newTime;
            Debug.Log("Rewind Button Pressed, new time: " + newTime);
        }
    }

    void FastForwardVideo()
    {
        if (videoPlayer != null)
        {
            double newTime = Mathf.Min((float)videoPlayer.time + 15f, (float)videoPlayer.length);
            videoPlayer.time = newTime;
            Debug.Log("Fast Forward Button Pressed, new time: " + newTime);
        }
    }

    void SetVolume(float volume)
    {
        if (videoPlayer != null)
        {
            videoPlayer.SetDirectAudioVolume(0, volume); // Assuming track 0 is the main track
            PlayerPrefs.SetFloat("VideoVolume", volume);
            Debug.Log("Volume set to: " + volume);
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == videoPlayer)
        {
            videoFinished = true;
            if (questionPanel != null)
            {
                questionPanel.SetActive(true);
            }

            // Resume background audio when video ends
            if (audioPausedByVideo && BackgroundAudioManager.instance != null)
            {
                BackgroundAudioManager.instance.ResumeAudio();
                audioPausedByVideo = false;
            }
        }
    }

    void OnDisable()
    {
        // Resume background audio if the scene changes while the video is still playing
        if (audioPausedByVideo && BackgroundAudioManager.instance != null)
        {
            BackgroundAudioManager.instance.ResumeAudio();
            audioPausedByVideo = false;
        }
    }
}
