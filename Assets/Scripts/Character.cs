using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Joystick joyStick;
    GameController gameController;
    public float moveSpeed = 5f;
    Rigidbody rg;
    Vector3 moveDirection;
    Animator anim;
    AudioSource audioSource;
    public AudioClip clipImpact;
    public AudioClip clipOut;
    public AudioClip clipHurt;
    private void Start()
    {
        gameController = GameController.Instance;
        audioSource = GetComponent<AudioSource>();
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
    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Food"))
        {
            PickFood();
        }
    }  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetHurt();
            if(collision.relativeVelocity.magnitude>16f)
            {
                //Debug.Log(collision.relativeVelocity.magnitude);
                audioSource.volume = 0.7f;
                audioSource.PlayOneShot(clipHurt);
            }
        }
    }
    public void GetHurt()
    {
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(clipImpact);    
    }
    public void PickFood()
    {
        audioSource.volume = 0.5f;
        audioSource.Play();
        gameController.SetScore();
    }
    public void MoveOut()
    {
        audioSource.PlayOneShot(clipOut);
        gameController.EndGame();
    }
}
