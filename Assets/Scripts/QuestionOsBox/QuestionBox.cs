using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBox : MonoBehaviour
{
    [SerializeField] private QuestionOS quesInBox;

    public void SetQuestionInBox(QuestionOS questionOS)
    {
        quesInBox = questionOS;
    }


}
