using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterControllerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController characterController;
    Vector3 localDir;
    Vector3 verticalVelo;
    public float speed;
    public float jump;
    Animator animator;
    const float gravity = 9.81f;
    float rotationY;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
    float vertical = Input.GetAxisRaw("Vertical");
    float horizontal = Input.GetAxisRaw("Horizontal");
    localDir = new Vector3(horizontal, 0, vertical);
    rotationY = Input.GetAxis("Mouse X");

    if (characterController.isGrounded)
    {
        verticalVelo.y = -1;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelo.y = jump;
        }        
    }
    else
    {
        verticalVelo.y -= gravity * Time.deltaTime;
    }
    if (horizontal != 0 || vertical != 0)

     {

            animator.SetBool("isWalking", true);

     }

    else

    {

            animator.SetBool("isWalking", false);

    }

        characterController.Move(transform.TransformDirection(localDir) * speed * Time.deltaTime);
    characterController.Move(verticalVelo * Time.deltaTime);

    transform.Rotate(0, rotationY, 0);
    }
}
