using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject CurrentCanvas;
    [SerializeField] private GameObject questionCanvas;
    [SerializeField] private QuestionSO QuestionInBox;
    // Start is called before the first frame update


    void Update()
    {
        Vector3 MiddleOfScreen = new Vector3(Screen.width/2f,Screen.height/2f,0f);
        if (transform.IsChildOf(Player) && Input.GetKeyDown(KeyCode.F))
        {   
            if (CurrentCanvas != null )
            {
                Destroy(CurrentCanvas);
                CurrentCanvas = null;
            }
            else
            {
                CurrentCanvas = Instantiate(questionCanvas,MiddleOfScreen,Quaternion.identity);
            }
        }
        else 
        if(!transform.IsChildOf(Player))
        {
             if (CurrentCanvas != null )
            {
                Destroy(CurrentCanvas);
                CurrentCanvas = null;
            }
        }
    }

    public void SetCurrentQuestion(QuestionSO question)
    {
        QuestionInBox = question;
    }
    
    public string GetCurrentQuestion()
    {
        return QuestionInBox.GetQuestionText();
    }
    
}
