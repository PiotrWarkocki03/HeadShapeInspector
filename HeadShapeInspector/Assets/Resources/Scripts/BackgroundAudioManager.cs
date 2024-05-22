using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundAudioManager : MonoBehaviour
{
    public static BackgroundAudioManager instance;
    public AudioSource audioSource;
    public Slider volumeSlider;

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
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
    }

    private void LoadVolumeSettings()
    {
        float volume = PlayerPrefs.GetFloat("BackgroundVolume", 1.0f); // Default volume is 1.0f
        audioSource.volume = volume;

        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
