using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Question OS" , menuName = "Question OS")]
public class QuestionOS : ScriptableObject
{
    [SerializeField] private new string question = "Enter a new question";
    [SerializeField] private string answer;
    [SerializeField] private float pointCanGet;

    public string GetQuestionText()
    {
        return question;
    }
    public string GetAnswerText()
    {
        return answer;
    }
    public float GetPoint()
    {
        return pointCanGet;
    }

    
}
