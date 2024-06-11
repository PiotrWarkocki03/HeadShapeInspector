using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FourOptionQManager : MonoBehaviour
{  
    public Button[] answerButtons;

    [SerializeField]
    private Button[] correctAnswers;

    private int currentQuestionIndex = 0;
    public GameObject correctOption;
    public GameObject incorrectOption;
    
    public int starsCount;
    
    [SerializeField] bool q1Correct; //number of attempts
    [SerializeField] bool q2Correct;
    [SerializeField] bool q3Correct;

    public Image[] stars;
    public Image[] resultsCorrectPanel;
    public Image[] resultsIncorrectPanel;

    public Sprite filledStar;
    public Sprite emptyStar;

    public GameObject q1;
    public GameObject q2;
    public GameObject q3;

    [SerializeField] TextMeshProUGUI q1Text;
    [SerializeField] TextMeshProUGUI q2Text;
    [SerializeField] TextMeshProUGUI q3Text;

    public GameManager gameManager;

    private string currentLevelName;

    private void Start()
    {

        q1Correct = false;
        q2Correct = false;
        q3Correct = false;
        starsCount = 3;
        
        //q1.SetActive(true);
        q2.SetActive(false);
        q3.SetActive(false);

        currentLevelName = SceneManager.GetActiveScene().name;
        gameManager = GameObject.Find("JsonManager").GetComponent<GameManager>();

        updateStars();
    }

    public void incorrectAnswer1()
    {
        q1Correct = false;
        q1Text.fontStyle = FontStyles.Strikethrough;
        Debug.Log("incorrect!");
        q1.SetActive(false);
        q2.SetActive(true);

        
        starsCount--;
        currentQuestionIndex++;
        updateStars();
    }
    public void incorrectAnswer2()
    {
        q2Correct = false;
        q2Text.fontStyle = FontStyles.Strikethrough;
        Debug.Log("incorrect!");
        q2.SetActive(false);
        q3.SetActive(true);      
        
        starsCount--;
        currentQuestionIndex++;
        updateStars();
    }

    public void incorrectAnswer3()
    {
        q3Correct = false;
        q3Text.fontStyle = FontStyles.Strikethrough;
        Debug.Log("incorrect!");
        
        starsCount--;
        updateStars();
        
        if(starsCount <= 1 )
        {
            incorrectOption.SetActive(true);
            Debug.Log("STARS:" + starsCount);

        }
        else
        {
            correctOption.SetActive(true);
            Debug.Log("STARS:" + starsCount);
        }
        
        
    }
    public void correctAnswer1()
    {
        Debug.Log("correct!");
        q1Correct = true;
        q1.SetActive(false);
        q2.SetActive(true);

        currentQuestionIndex++;
        updateStars();
    }
    public void correctAnswer2()
    {
        Debug.Log("correct!");
        q2Correct = true;
        q2.SetActive(false);
        q3.SetActive(true);

        currentQuestionIndex++;
        updateStars();
    }
    public void correctAnswer3()
    {
        Debug.Log("correct!");
        q3Correct = true;
        //q2.SetActive(false);
        //q3.SetActive(true);

        
        updateStars();

        if (starsCount <= 1)
        {
            incorrectOption.SetActive(true);
            Debug.Log("STARS:"+starsCount);
        }
        else
        {
            correctOption.SetActive(true);
            Debug.Log("STARS:" + starsCount);
        }
    }

    public void SelectAnswer(int answerIndex)
    {

        if (answerIndex == GetCorrectAnswerIndex())
        {
            
            int i = gameManager.GetScoreForLevel(currentLevelName);

            if (starsCount > i)
            {
                gameManager.SaveScoreForLevel(currentLevelName,starsCount);
            }
        }
        
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
        Debug.Log("Updating stars display. Stars count: " + starsCount);

        foreach (var item in stars)
        {
            item.sprite = emptyStar;
        }

        for (int i = 0; i < Mathf.Min(starsCount, stars.Length); i++)
        {
            stars[i].sprite = filledStar;
        }

        foreach (var item in resultsCorrectPanel)
        {
            item.sprite = emptyStar;
        }

        for (int i = 0; i < Mathf.Min(starsCount, resultsCorrectPanel.Length); i++)
        {
            resultsCorrectPanel[i].sprite = filledStar;
        }

        foreach (var item in resultsIncorrectPanel)
        {
            item.sprite = emptyStar;
        }

        for (int i = 0; i < Mathf.Min(starsCount, resultsIncorrectPanel.Length); i++)
        {
            resultsIncorrectPanel[i].sprite = filledStar;
        }


    }

    
}