using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cityzen : MonoBehaviour
{
    public Transform target;
    public Transform posSpaw;
    public GameObject item;
   // public Button btnTest;
    Animator anim;
    private void Awake()
    {
        Invoke(nameof(SetActivePlayer), 2f);
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        //btnTest.onClick.AddListener(() => Throw());

    }
    private void Update()
    {
    
    }   
    public void Throwing()
    {
        Debug.Log("girl throwing");
        GameObject tempObj = Instantiate(item, posSpaw.position, Quaternion.identity) as GameObject;
        //tempObj.GetComponent<ItemController>().posTarget = target.position;
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
