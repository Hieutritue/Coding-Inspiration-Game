using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform QuestionBoxes;
    [SerializeField] private Transform HeadPosition;
    [SerializeField] private Transform HandPosition;
    [SerializeField] LayerMask pickupMask;
    [SerializeField] float PickUpCheckDistance = .5f;
    [SerializeField] GameObject CheckItemPoint;
    
    public Rigidbody itemHolding = null;
  
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding)
            {
                itemHolding.transform.localScale *=2;
                itemHolding.GetComponent<Rigidbody>().isKinematic = false;
                itemHolding.transform.SetParent(QuestionBoxes);
                itemHolding.useGravity = true;
                itemHolding = null;
            }            
            else
            {
                Ray playerRay = new Ray(CheckItemPoint.transform.position,transform.forward);
                 
                if (Physics.Raycast(playerRay,out RaycastHit hitInfo, PickUpCheckDistance,pickupMask))
                {
                    itemHolding = hitInfo.rigidbody;
                    itemHolding.useGravity = false;
                    itemHolding.transform.SetParent(transform);
                    itemHolding.transform.localScale /=2;
                    itemHolding.transform.localRotation = quaternion.identity;
                    itemHolding.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        } 
    }

    void FixedUpdate()
    {
        if (itemHolding)
        {
            itemHolding.transform.position = HandPosition.position;
        }
    }

    public GameObject GetItemHolding()
    {
            return itemHolding.gameObject;
    }
}



