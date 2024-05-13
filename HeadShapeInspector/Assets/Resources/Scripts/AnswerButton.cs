using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public int answerIndex;
    public QuestionnaireManager questionnaireManager;
    

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        questionnaireManager.SelectAnswer(answerIndex);
    }
}
