using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question",fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,4)]
    public string questionText;
    public string answer;

    public string GetQuestionText()
    {
        return questionText;
    }
}
