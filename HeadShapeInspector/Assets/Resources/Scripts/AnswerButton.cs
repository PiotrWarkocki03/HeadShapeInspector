using UnityEngine;
using UnityEngine.UI;


/*interaction between answer buttons and the question manager.
Allows for answer selection*/
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
