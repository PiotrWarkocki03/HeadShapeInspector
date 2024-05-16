using UnityEngine;
using UnityEngine.UI;

public class LevelPlayed : MonoBehaviour
{
    public Image imageToChange;
    public Text textToChange;
    public float minOpacity = 0.5f; // 50%
    public float maxOpacity = 1.0f; // 100%
    private bool hasOpacityChanged = false; // Flag to track if opacity has already changed

    void Start()
    {
        // Ensure image and text are assigned
        if (imageToChange == null || textToChange == null)
        {
            Debug.LogError("No image or text assigned to ChangeImageAndTextOpacity script on GameObject: " + gameObject.name);
            enabled = false; // Disable the script if no image or text is assigned
        }

        // Get the button component and add a listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeOpacity);
        }
        else
        {
            Debug.LogError("No button component found on GameObject: " + gameObject.name);
        }

        // Load the saved opacity value for both image and text
        float savedImageOpacity = PlayerPrefs.GetFloat(gameObject.name + "_ImageOpacity", minOpacity); // Use the GameObject's name as a unique key
        ApplyImageOpacity(savedImageOpacity);
        if (savedImageOpacity != minOpacity)
        {
            hasOpacityChanged = true;
        }

        float savedTextOpacity = PlayerPrefs.GetFloat(gameObject.name + "_TextOpacity", minOpacity);
        ApplyTextOpacity(savedTextOpacity);
    }

    public void ChangeOpacity()
    {
        if (!hasOpacityChanged)
        {
            ApplyImageOpacity(maxOpacity);
            ApplyTextOpacity(maxOpacity);
            hasOpacityChanged = true;

            // Save the opacity value for both image and text
            PlayerPrefs.SetFloat(gameObject.name + "_ImageOpacity", maxOpacity); // Use the GameObject's name as a unique key
            PlayerPrefs.SetFloat(gameObject.name + "_TextOpacity", maxOpacity);
            PlayerPrefs.Save();
        }
    }

    private void ApplyImageOpacity(float opacity)
    {
        // Apply opacity to the image
        if (imageToChange != null)
        {
            Color imageColor = imageToChange.color;
            imageColor.a = opacity;
            imageToChange.color = imageColor;
        }
    }

    private void ApplyTextOpacity(float opacity)
    {
        // Apply opacity to the text
        if (textToChange != null)
        {
            Color textColor = textToChange.color;
            textColor.a = opacity;
            textToChange.color = textColor;
        }
    }

    // Clear PlayerPrefs if needed
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteKey(gameObject.name + "_ImageOpacity");
        PlayerPrefs.DeleteKey(gameObject.name + "_TextOpacity");
        PlayerPrefs.Save();
        hasOpacityChanged = false; // Reset the flag
    }
}
