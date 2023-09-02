using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class QuestionCanvas : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] Transform Player;
    [SerializeField] private GameObject BoxObject;
    public TextMeshProUGUI QuestionText;
    GameObject ItemHolding;


    void Update()
    {
        
        ItemHolding = Player.GetComponent<PlayerPickUp>().GetItemHolding();
        if (ItemHolding!=null)
        {
            if (ItemHolding.tag.Equals("Item"))
            {
                BoxObject = ItemHolding;
            }
            else
            if (!ItemHolding.transform.IsChildOf(Player))
            {
                BoxObject = null;
            }
        }
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        if (BoxObject.GetComponent<Box>().GetCurrentQuestion() !=null && BoxObject != null)
        {
            QuestionText.text = BoxObject.GetComponent<Box>().GetCurrentQuestion();
        }
        
    }
}
