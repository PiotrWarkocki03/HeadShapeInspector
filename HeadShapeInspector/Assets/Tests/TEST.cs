 using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class TEST : MonoBehaviour
{  
    public Button[] answerButtons;

    [SerializeField]
    private Button[] correctAnswers;

    private int currentQuestionIndex = 0;
    public GameObject correctOption;
    public GameObject incorrectOption;

    public TimeManager timeManager;
    
    public int starsCount;

    [SerializeField] bool retryUsed; //number of attempts
    [SerializeField] bool hintUsed;
    [SerializeField] bool timesUp;

    public Image[] stars;
    public Image[] results;

    public Sprite filledStar;
    public Sprite emptyStar;

    public float timeLimit;

    [SerializeField] TextMeshProUGUI usedHint;
    [SerializeField] TextMeshProUGUI usedRetry;
    [SerializeField] TextMeshProUGUI timeLimitReached;
    
    public GameObject tick1;
    public GameObject x1;
    public GameObject tick2;
    public GameObject x2;
    public GameObject tick3;
    public GameObject x3;

    private void Start()
    {
        retryUsed = false;
        hintUsed = false;
        timesUp = false;
        starsCount = 3;
        timeLimit = 5f;
        tick1.SetActive(true);
        tick2.SetActive(true);
        tick3.SetActive(true);


        starsCount = PlayerPrefs.GetInt("starsCount");
    }
    public void SaveData()
    {
        //bool
        PlayerPrefs.SetInt("starsCount", starsCount);
        Debug.Log("Saving Data.....");

    }
    public void UseHint()
    {
        if(hintUsed == false)
        {
            hintUsed = true;
            starsCount--;
            updateStars();
            usedHint.fontStyle = FontStyles.Strikethrough;
            tick1.SetActive(false);
            x1.SetActive(true);
            Debug.Log("Star 1 Lost");
        }
    }

    public void UseRetry()
    {
        if(retryUsed == false)
        {
            retryUsed = true;
            starsCount--;
            updateStars();
            usedRetry.fontStyle = FontStyles.Strikethrough;
            tick2.SetActive(false);
            x2.SetActive(true);
            Debug.Log("Star 2 Lost");
        }
    }

    public void SelectAnswer(int answerIndex)
    {
        if (answerIndex == GetCorrectAnswerIndex())
        {
            correctOption.SetActive(true);
            incorrectOption.SetActive(false);
            Debug.Log("Correct Answer Chosen!");

        }
        else
        {
            incorrectOption.SetActive(true);
            correctOption.SetActive(false);
            Debug.Log("Incorrect Answer Chosen!");
        }
        timeManager.PauseTimer();

    }
    private int GetCorrectAnswerIndex()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (correctAnswers[currentQuestionIndex] == answerButtons[i])
            {
                return i;
            }
        }
        return -1; // Return -1 if the correct answer is not found
    }
    private void updateStars()
    {
        foreach (var item in stars)
        {
            item.sprite = emptyStar;
        }

        for (int i = 0; i < starsCount; i++)
        {
            stars[i].sprite = filledStar;
        }
        
        foreach (var item in results)
        {
            item.sprite = emptyStar;
        }

        for (int i = 0; i < starsCount; i++)
        {
            results[i].sprite = filledStar;
        }
    }
    private void TimeCheck()
    {
        if(timesUp == false)
        {
            if (timeManager.getTimer() > timeLimit)
            {
                starsCount--;
                updateStars();
                timeLimitReached.fontStyle = FontStyles.Strikethrough;
                tick3.SetActive(false);
                x3.SetActive(true);
                timesUp = true;
                Debug.Log("Star 3 Lost");
            }
        }
    }

    private void Update()
    {
        TimeCheck();
    }

    
}