using UnityEditor;
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

    public TimeManager timeManager;

    
    

    public void SelectAnswer(int answerIndex)
    {
        if (answerIndex == GetCorrectAnswerIndex())
        {
            
            correctOption.SetActive(true);
            incorrectOption.SetActive(false);
            timeManager.PauseTimer();
            

        }
        else
        {
            
            incorrectOption.SetActive(true);
            correctOption.SetActive(false);
            timeManager.PauseTimer();

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


    

    

   
}