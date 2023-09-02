using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform cam;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask CanJumpMask;
    [SerializeField] float speed = 6f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelocity;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -9.81f*2;
    float groundDistance = 0.4f;
    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    { 
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,CanJumpMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction  = new Vector3(horizontal,0f,vertical).normalized;
        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            Vector3 moveDirection = Quaternion.Euler(9f,targetAngle,0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * speed *Time.deltaTime); 
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }
}
