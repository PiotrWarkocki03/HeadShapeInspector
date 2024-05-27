using UnityEngine;
using UnityEngine.UI;

/* Manages the functionality for playing an audio clip when a button is clicked. 
This script ensures that an audio source component is attached to the button's GameObject, 
and assigns the specified audio clip to it. When the button is clicked, the assigned audio clip is played.*/

public class ButtonAudio : MonoBehaviour
{
    // Audio clip to play
    public AudioClip soundClip;

    // Reference to the button
    private Button button;

    // Reference to the audio source
    private AudioSource audioSource;

    void Start()
    {
        // Get the button component
        button = GetComponent<Button>();

        // Add a listener to the button click
        button.onClick.AddListener(PlaySound);

        // Get the AudioSource component (you can add this component to the same GameObject)
        audioSource = GetComponent<AudioSource>();

        // If there is no AudioSource component, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the sound clip to the audio source
        audioSource.clip = soundClip;
    }

    // Function to play the sound
    void PlaySound()
    {
        // Play the audio clip
        audioSource.Play();
    }
}
