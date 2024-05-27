using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*script used to manage background audio volume
 Slider interaction allows for volume changing
Playerprefs make it possible to save volume settings for when game is restarted*/

public class BackgroundAudioManager : MonoBehaviour
{
    public static BackgroundAudioManager instance;
    public AudioSource audioSource;
    public Slider volumeSlider;
    

    private bool isMuted = false;
    private Image muteButtonImage;

    private const string MuteKey = "IsMuted";
    private const string VolumeKey = "BackgroundVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        AssignSliderTarget();
        LoadVolumeSettings();
        

        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignSliderTarget();
        LoadVolumeSettings();
        
    }

    void AssignSliderTarget()
    {
        volumeSlider = GameObject.FindGameObjectWithTag("Volume")?.GetComponent<Slider>();
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
            PlayerPrefs.SetFloat(VolumeKey, volume);
            
        }
    }

    private void LoadVolumeSettings()
    {
        float volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f); // Default volume is 0.5f
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }

        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
        }

        isMuted = PlayerPrefs.GetInt(MuteKey, 0) == 1;
     
    }
    public void PauseAudio()
    {
        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }
    public void ResumeAudio()
    {
        if (audioSource != null)
        {
            audioSource.UnPause();
        }
    }
    public void ToggleMute()
    {
        isMuted = !isMuted;
        if (audioSource != null)
        {
            if (isMuted)
            {
                PlayerPrefs.SetFloat(VolumeKey, audioSource.volume);
                audioSource.volume = 0;
            }
            else
            {
                audioSource.volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f); // Default volume is 0.5f
            }
            
            PlayerPrefs.SetInt(MuteKey, isMuted ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
