using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfQuesSO : MonoBehaviour
{
    public List<QuestionSO> questionList = new List<QuestionSO>();
    
    void Start()
    {
        List<Transform> ChildrenTranform = new List<Transform>();
        
        foreach (Transform child in transform)
        {
            ChildrenTranform.Add(child);
        }

        for (int i = 0; i < ChildrenTranform.Count; i++)
        {
            int randomIndex = Random.Range(i,ChildrenTranform.Count);
            Transform temp = ChildrenTranform[i];
            ChildrenTranform[i] = ChildrenTranform[randomIndex];
            ChildrenTranform[randomIndex] = temp;
        }

        for (int i = 0; i < ChildrenTranform.Count; i++)
        {
            ChildrenTranform[i].SetSiblingIndex(i);
        }

        for (int i = 0; i < ChildrenTranform.Count; i++)
        {
            ChildrenTranform[i].GetComponent<Box>().SetCurrentQuestion(GetRandomQuesionSO());
        }

    }
    QuestionSO GetRandomQuesionSO()
    {
            if (questionList.Count > 0)
            {
                int randomIndex = Random.Range(0, questionList.Count);
                QuestionSO randomQuestion = questionList[randomIndex];
                if (questionList.Contains(randomQuestion))
                {
                    questionList.RemoveAt(randomIndex);
                }
                return randomQuestion;

            }
            else return null;
    }
}
