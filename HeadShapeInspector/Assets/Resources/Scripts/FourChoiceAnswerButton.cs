using UnityEngine;
using UnityEngine.UI;

public class FourChoiceAnswerButton : MonoBehaviour
{
    public int answerIndex;
    public FourOptionQManager questionnaireManager;
    

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
