using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupStarsManager : MonoBehaviour
{
    [SerializeField] private string[] g1_levelNames;

    [SerializeField] private string[] g2_levelNames;

    [SerializeField] private string[] g3_levelNames;

    [SerializeField] private Sprite emptySprite;
    [SerializeField] private Sprite filledSprite;

    [SerializeField] private Image[] starsSprites;

    private GameManager gameManager;

    [SerializeField] private int threshold_1;
    [SerializeField] private int threshold_2;
    [SerializeField] private int threshold_3;

    //[SerializeField] private Button h1;
    [SerializeField] private Button button_h2;
    [SerializeField] private Button button_h3;


    //Head1 not needed, it will always be playable
    // [SerializeField] private GameObject Head1;
    [SerializeField] private GameObject Lock2;
    [SerializeField] private GameObject Lock3;

    [SerializeField] private GameObject Ui2;
    [SerializeField] private GameObject Ui3;

    //[SerializeField] private Text Level1;
    //[SerializeField] private Text Level2;
    //[SerializeField] private Text Level3;

    // Start is called before the first frame update
    void Start()
    {
        emptySprite = Resources.Load<Sprite>("Sprites/Black Star");
        filledSprite = Resources.Load<Sprite>("Sprites/Yellow Star");

        //starsSprites = this.GetComponentsInChildren<Image>();

        gameManager = GameObject.Find("JsonManager").GetComponent<GameManager>();
        Lock2.SetActive(true);
        Lock3.SetActive(true);

        Ui2.SetActive(false);
        Ui3.SetActive(false);

        button_h2.interactable = false;
        button_h3.interactable = false;
        updateStars();

     } 
     
    private void updateStars()
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
                starsAcc1 = starsAcc1 + levelScore;
                
                Debug.Log(levelScore);
            }
        }

        foreach (var item in g2_levelNames)
        {
            levelScore = gameManager.GetScoreForLevel(item);

            if (levelScore > -1)
            {
                starsAcc2 = starsAcc2 + levelScore;
                Debug.Log(levelScore);
            }
        }

        foreach (var item in g3_levelNames)
        {
            levelScore = gameManager.GetScoreForLevel(item);

            if (levelScore > -1)
            {
                starsAcc3 = starsAcc3 + levelScore;
                Debug.Log(levelScore);
            }
        }

        Debug.Log("TOTAL stars in Level1: " + starsAcc1.ToString());
        Debug.Log("TOTAL stars in Level2: " + starsAcc2.ToString());
        Debug.Log("TOTAL stars in Level3: " + starsAcc3.ToString());


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
