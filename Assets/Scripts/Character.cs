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
    Animator anim;
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float moveX = joyStick.Horizontal;
        float moveY = joyStick.Vertical;
        moveDirection = new Vector3(moveX, 0, moveY);
        moveDirection.Normalize();     
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;  
        transform.localPosition += movement;  
        
        if(moveDirection.magnitude>0)
        {
            anim.SetFloat("Speed", 1f);
        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }
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
