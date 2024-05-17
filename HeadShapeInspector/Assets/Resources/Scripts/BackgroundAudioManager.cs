using UnityEngine;
using UnityEngine.UI;

public class BackgroundAudioManager : MonoBehaviour
{
    public static BackgroundAudioManager instance;
    public AudioSource audioSource;
    public Slider volumeSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        LoadVolumeSettings();
    }


    private void Start()
    {
        // Find the GameObject named "VolumeSlider" and get its Slider component
        GameObject sliderObject = GameObject.Find("VolumeSlider");
        if (sliderObject != null)
        {
            volumeSlider = sliderObject.GetComponent<Slider>();
        }

        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            Debug.LogError("VolumeSlider GameObject not found or does not have a Slider component.");
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
        PlayerPrefs.Save();
    }

    private void LoadVolumeSettings()
    {
        if (PlayerPrefs.HasKey("BackgroundVolume"))
        {
            float volume = PlayerPrefs.GetFloat("BackgroundVolume");
            audioSource.volume = volume;
        }
        else
        {
            audioSource.volume = 1.0f; // Default volume
        }
    }
}
