using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*Manages the functionality of a questionnaire, including answering questions,
managing hints and retries, and tracking + updating stars and time limits.*/

public class QuestionnaireManager : MonoBehaviour
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
    
    public GameManager gameManager;

    private string currentLevelName;

    private void Start()
    {
        retryUsed = false;
        hintUsed = false;
        timesUp = false;
        starsCount = 3;
        timeLimit = 10f;
        
        currentLevelName = SceneManager.GetActiveScene().name;

        gameManager = GameObject.Find("JsonManager").GetComponent<GameManager>();
    }

    public void UseHint()
    {
        //If hint used change the bool to true and take away star from the current Level
        if (hintUsed == false)
        {
            hintUsed = true;
            starsCount--;
            //calls the updateStars Method
            updateStars();
            //Add a strikethrough the text
            usedHint.fontStyle = FontStyles.Strikethrough;
            
        }
    }
    public void UseRetry()
    {
        //If retry is used change the bool to true and take away star from the current Level
        if(retryUsed == false)
        {
            retryUsed = true;
            starsCount--;
            //calls the updateStars Method
            updateStars();
            //Add a strikethrough the text
            usedRetry.fontStyle = FontStyles.Strikethrough;  
        }
    }

    public void SelectAnswer(int answerIndex)
    {
        if (answerIndex == GetCorrectAnswerIndex())
        {
            correctOption.SetActive(true);
            incorrectOption.SetActive(false);

            int i = gameManager.GetScoreForLevel(currentLevelName);

            if (starsCount > i)
            {
                gameManager.SaveScoreForLevel(currentLevelName,starsCount);
            }
        }
        else
        {
            incorrectOption.SetActive(true);
            correctOption.SetActive(false);
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
        //If the timer is up the player loses a star in that level 
        if(timesUp == false)
        {
            if (timeManager.getTimer() > timeLimit)
            {
                starsCount--;
                //calls the updateStars Method
                updateStars();
                //Add a strikethrough the texts
                timeLimitReached.fontStyle = FontStyles.Strikethrough;
                
                timesUp = true;
            }
        }
    }
    private void Update()
    {
        TimeCheck();
    }
}