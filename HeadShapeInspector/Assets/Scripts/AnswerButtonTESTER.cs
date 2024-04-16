using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonTESTER : MonoBehaviour
{
    public int answerIndex;
    public TEST qTest;
    

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        qTest.SelectAnswer(answerIndex);
    }
}
