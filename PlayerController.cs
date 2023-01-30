using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpSpeed = 8.0f;
    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horiz, 0, vert);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (charController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= 9.8f * Time.deltaTime;
        charController.Move(moveDirection * Time.deltaTime);
    }
}
