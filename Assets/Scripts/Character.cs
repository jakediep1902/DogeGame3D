using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Joystick joyStick;
    public float moveSpeed = 5f;
    Rigidbody rg;
    Vector3 moveDirection;  
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float moveX = joyStick.Horizontal;
        float moveY = joyStick.Vertical;
        moveDirection = new Vector3(moveX, 0, moveY);
        moveDirection.Normalize();     
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;  
        transform.localPosition += movement;               
    }
    private void LateUpdate()
    {
        RotatePlayer();
    }
    public void RotatePlayer()
    {       
        if (moveDirection != Vector3.zero)
        {              
            transform.localRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        }
    }

}
