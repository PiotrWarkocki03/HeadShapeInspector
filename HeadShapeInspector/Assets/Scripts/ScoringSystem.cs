using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public static ScoringSystem Instance; // Singleton instance

    public int totalQuestionsPerLevel = 5; // Total number of questions per level
    public int correctAnswersNeededForStar1 = 5; // Number of correct answers needed for the first star
    public int timeLimitInSecondsForStar3 = 30; // Time limit in seconds for the third star
    public bool useHintsForStar2 = false; // Whether to allow using hints for the second star

    private int currentQuestionIndex = 0; // Index of the current question
    private int correctAnswers = 0; // Number of correct answers
    private bool usedHint = false; // Whether the player used the hint
    private bool answeredInTime = false; // Whether the player answered within the time limit

    private bool star1Obtained = false;
    private bool star2Obtained = false;
    private bool star3Obtained = false;

    // Initialize the singleton instance
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this method when the player answers a question
    public void AnswerQuestion(bool isCorrect)
    {
        if (isCorrect)
        {
            correctAnswers++;
        }
        UpdateStarProgress();
        currentQuestionIndex++;
    }

    // Call this method when the player uses a hint
    public void UseHint()
    {
        usedHint = true;
        UpdateStarProgress();
    }

    // Call this method when the player answers within the time limit
    public void AnsweredInTime()
    {
        answeredInTime = true;
        UpdateStarProgress();
    }

    // Update star progress based on current conditions
    private void UpdateStarProgress()
    {
        if (correctAnswers >= correctAnswersNeededForStar1)
        {
            star1Obtained = true;
        }

        if (!useHintsForStar2 || !usedHint)
        {
            star2Obtained = true;
        }

        if (!star3Obtained && answeredInTime)
        {
            star3Obtained = true;
        }
    }

    // Call this method to reset the scoring system for a new level
    public void ResetLevel()
    {
        currentQuestionIndex = 0;
        correctAnswers = 0;
        usedHint = false;
        answeredInTime = false;
        star1Obtained = false;
        star2Obtained = false;
        star3Obtained = false;
    }

    // Getters for star status
    public bool Star1Obtained => star1Obtained;
    public bool Star2Obtained => star2Obtained;
    public bool Star3Obtained => star3Obtained;
}
