using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Manages the display of stars based on the score achieved in a specific level.
Updates star sprite depending on the star amount */
public class StarsManager : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private Sprite emptySprite;
    [SerializeField] private Sprite filledSprite;
    [SerializeField] private Image[] starsSprites;
    private GameManager gameManager;

    [SerializeField] private Image parentSprite;

    private float defaultOpacity = 1f; // Default opacity value
    private string opacityKey; // Key to save/load opacity

    void Start()
    {
        // Load the Black And Yellow Star sprites in the Sprite slots in the inspector
        emptySprite = Resources.Load<Sprite>("Sprites/Black Star");
        filledSprite = Resources.Load<Sprite>("Sprites/Yellow Star");

        parentSprite = GetComponentInParent<Image>();
        if (parentSprite == null)
        {
            Debug.LogError("Parent Image component not found.");
            return; // Exit if parent image component not found
        }

        starsSprites = this.GetComponentsInChildren<Image>();

        gameManager = GameObject.Find("JsonManager").GetComponent<GameManager>();

        // Generate unique key for saving opacity
        opacityKey = "Opacity_" + gameObject.name;

        // Load opacity from PlayerPrefs, use default opacity if not found
        float savedOpacity = PlayerPrefs.GetFloat(opacityKey, defaultOpacity);
        SetParentOpacity(savedOpacity);

        updateStars();
    }

    private void updateStars()
    {
        int score = gameManager.GetScoreForLevel(levelName);

        foreach (var item in starsSprites)
        {
            item.sprite = emptySprite;
        }

        for (int i = 0; i < score; i++)
        {
            starsSprites[i].sprite = filledSprite;
        }

        // Ensure alpha is set correctly regardless of the score
        float alpha = score >= 0 ? 1.0f : 0.2f;
        SetParentOpacity(alpha);
    }

    private void SetParentOpacity(float alpha)
    {
        Color parentColor = parentSprite.color;
        parentColor.a = alpha;
        parentSprite.color = parentColor;

        // Save opacity to PlayerPrefs
        PlayerPrefs.SetFloat(opacityKey, alpha);
        PlayerPrefs.Save(); // Save PlayerPrefs data immediately
    }
}
