using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*Manages the display and unlocking of levels based on accumulated stars in different difficulty groups.
Updates the star ammount and star text based on accumulated stars.*/ 
public class GroupStarsManager : MonoBehaviour
{

    //String arrays for each level difficulty
    [SerializeField] private string[] g1_levelNames;
    [SerializeField] private string[] g2_levelNames;
    [SerializeField] private string[] g3_levelNames;

    //Sprite arrays for empty and filled sprites
    [SerializeField] private Sprite emptySprite;
    [SerializeField] private Sprite filledSprite;
    //Image arrays for the star sprites 
    [SerializeField] private Image[] starsSprites;
    //Text arrays for the star texts
    [SerializeField] private Text[] starsTexts;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private int threshold_1;
    [SerializeField] private int threshold_2;
    [SerializeField] private int threshold_3;

    [SerializeField] private Button button_h2;
    [SerializeField] private Button button_h3;

    [SerializeField] private GameObject Lock2;
    [SerializeField] private GameObject Lock3;

    [SerializeField] private GameObject Ui2;
    [SerializeField] private GameObject Ui3;
    void Start()
    {
        emptySprite = Resources.Load<Sprite>("Sprites/Black Star");
        filledSprite = Resources.Load<Sprite>("Sprites/Yellow Star");

        gameManager = GameObject.Find("JsonManager").GetComponent<GameManager>();
        Lock2.SetActive(true);
        Lock3.SetActive(true);

        Ui2.SetActive(false);
        Ui3.SetActive(false);

        button_h2.interactable = false;
        button_h3.interactable = false;       
        updateStars();
    }

    public void updateStars()
    {
        int starsAcc1 = 0;
        int starsAcc2 = 0;
        int starsAcc3 = 0;

        int levelScore;

        foreach (var item in g1_levelNames)
        {
            levelScore = gameManager.GetScoreForLevel(item);

            if (levelScore > -1)
            {
                starsAcc1 += levelScore;
                Debug.Log(levelScore);
            }
        }

        foreach (var item in g2_levelNames)
        {
            levelScore = gameManager.GetScoreForLevel(item);

            if (levelScore > -1)
            {
                starsAcc2 += levelScore;
                Debug.Log(levelScore);
            }
        }

        foreach (var item in g3_levelNames)
        {
            levelScore = gameManager.GetScoreForLevel(item);

            if (levelScore > -1)
            {
                starsAcc3 += levelScore;
                Debug.Log(levelScore);
            }
        }
        //Prints the star amount for each difficulty in the Unity Console
        Debug.Log("TOTAL stars in Difficulty1: " + starsAcc1);
        Debug.Log("TOTAL stars in Difficulty2: " + starsAcc2);
        Debug.Log("TOTAL stars in Difficulty3: " + starsAcc3);

        //Prints the star amount for each difficulty in starsText field in the DifficultySelector scene
        starsTexts[0].text = starsAcc1.ToString() + "/60";
        starsTexts[1].text = starsAcc2.ToString() + "/60";
        starsTexts[2].text = starsAcc3.ToString() + "/60";

        foreach (var item in starsSprites)
        {
            item.sprite = emptySprite;
        }

        if (starsAcc1 >= threshold_1)
        {
            starsSprites[0].sprite = filledSprite;
        }

        if (starsAcc1 >= threshold_2)
        {
            starsSprites[1].sprite = filledSprite;
            Ui2.SetActive(true);
            Lock2.SetActive(false);
            button_h2.interactable = true;
            Debug.Log("LEVEL2 UNLOCKED!");
        }

        if (starsAcc1 == threshold_3)
        {
            starsSprites[2].sprite = filledSprite;
        }
        if (starsAcc2 >= threshold_1)
        {
            starsSprites[3].sprite = filledSprite;
        }
        if (starsAcc2 >= threshold_2)
        {
            starsSprites[4].sprite = filledSprite;
            Ui3.SetActive(true);
            Lock3.SetActive(false);
            button_h3.interactable = true;
            Debug.Log("LEVEL3 UNLOCKED!");
        }
        if (starsAcc2 == threshold_3)
        {
            starsSprites[5].sprite = filledSprite;
        }
        if (starsAcc3 >= threshold_1)
        {
            starsSprites[6].sprite = filledSprite;
        }
        if (starsAcc3 >= threshold_2)
        {
            starsSprites[7].sprite = filledSprite;
        }

        if (starsAcc3 == threshold_3)
        {
            starsSprites[8].sprite = filledSprite;
        }
    }

    





}
