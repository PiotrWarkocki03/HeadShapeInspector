using UnityEngine;
using UnityEngine.UI;

public class QuestionnaireManager : MonoBehaviour
{
    //public Text questionText;
    public Button[] answerButtons;
    //public Text answerResultText;

    // Change correctAnswers to public and serialize it
    [SerializeField]
    private Button[] correctAnswers;

    private int currentQuestionIndex = 0;
    public GameObject correctOption;
    public GameObject incorrectOption;


    void Start()
    {
        // Display the first question
        DisplayQuestion(currentQuestionIndex);
    }

    public void SelectAnswer(int answerIndex)
    {
        if (answerIndex == GetCorrectAnswerIndex())
        {
            //answerResultText.text = "Correct!";
            correctOption.SetActive(true);
            incorrectOption.SetActive(false);
        }
        else
        {
            //answerResultText.text = "Incorrect!";
            incorrectOption.SetActive(true);
            correctOption.SetActive(false);
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

    public void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < answerButtons.Length)
        {
            DisplayQuestion(currentQuestionIndex);
        }
        else
        {
            Debug.Log("Questionnaire completed!");
            // Optionally, display a completion message or perform other actions
        }
    }

    private void DisplayQuestion(int index)
    {
        // Update question text here if needed
        //answerResultText.text = ""; // Clear previous answer result
    }
}
