using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

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

 

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignNewTarget();
    }

    void AssignNewTarget()
    {
        // Define the layer mask for the "Baby" layer
        int layerMask = 1 << LayerMask.NameToLayer("Volume");

        // Find all GameObjects in the "Baby" layer
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            
        }

        if (volumeSlider == null)
        {
            Debug.LogError("No suitable GameObject on the 'Baby' layer found in the scene.");
        }
    }


    private void Start()
    {

        AssignNewTarget();
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
