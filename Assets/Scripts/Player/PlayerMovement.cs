using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speedMovement = 5f;
    [SerializeField] float rotationSpeed = .1f;
    [SerializeField] float jumpHeight = 5f;
    Vector2 move;
    Vector3 playerVelocity;
    bool isJumping = false;
    float gravity = -9.81f*2;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
        Jumping();
    }

    #region InputSystem
    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    public void OnJump() {
       if (characterController.velocity.y == 0)
        {
            isJumping = true;
        }
    }

    #endregion 

    void Movement()
    {
        if (move.magnitude > Mathf.Epsilon)
        {
            Vector3 moveVector = new Vector3(move.x,0f,move.y);
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(moveVector),rotationSpeed);
            characterController.Move(moveVector * speedMovement * Time.deltaTime);
        }
    }

    void Jumping()
    {
        //check if player on the ground
       if (characterController.isGrounded)
       {
            playerVelocity.y = 0f;

            if (isJumping)
            {
                playerVelocity.y += Mathf.Sqrt(-2 * jumpHeight * gravity);
                isJumping = false;
            }
       }
       playerVelocity.y += gravity * Time.deltaTime;
       characterController.Move(playerVelocity * Time.deltaTime);
    }

}
