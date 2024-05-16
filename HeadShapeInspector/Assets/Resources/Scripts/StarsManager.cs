using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{
    [SerializeField] private string levelName;

    [SerializeField] private Sprite emptySprite;
    [SerializeField] private Sprite filledSprite;

    [SerializeField] private Image[] starsSprites;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        emptySprite = Resources.Load<Sprite>("Sprites/Black Star");
        filledSprite = Resources.Load<Sprite>("Sprites/Yellow Star");
        
        starsSprites = this.GetComponentsInChildren<Image>();

        gameManager = GameObject.Find("JsonManager").GetComponent<GameManager>();

        updateStars();
    }


    private void updateStars()
    {
        foreach (var item in starsSprites)
        {
            item.sprite = emptySprite;
        }

        int score = gameManager.GetScoreForLevel(levelName);

        for (int i = 0; i < score; i++)
        {
            starsSprites[i].sprite = filledSprite;
        }
    }
}