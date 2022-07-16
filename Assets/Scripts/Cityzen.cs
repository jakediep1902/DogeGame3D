using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cityzen : MonoBehaviour
{
    public Transform target;
    public Transform posSpaw;

    public GameObject item;
    
    AudioSource audioSource;
   // public Button btnTest;
    Animator anim;
    private void Awake()
    {
        //Invoke(nameof(SetActivePlayer), 2f);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        //btnTest.onClick.AddListener(() => Throw());
        SetActivePlayer();

    }
    private void Update()
    {
    
    }   
    public void Throwing()
    {
        //Debug.Log("girl throwing");
        GameObject tempObj = Instantiate(item, posSpaw.position, Quaternion.EulerRotation(30f,20f,100f)) as GameObject;
        tempObj.GetComponent<ItemController>().MoveStraight();
        audioSource.Play();
        Destroy(tempObj, 5f);
    }
    public void ThrowParabola()
    {
        GameObject tempObj = Instantiate(item, posSpaw.position, Quaternion.identity) as GameObject;
        tempObj.GetComponent<ItemController>().MoveParabola();
    }

    public void LookTarget()
    {
        transform.LookAt(target);      
    }
   public void SetActivePlayer()
    {
        anim.SetTrigger("Throw");
    }
   
    
       
}
