using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cityzen : MonoBehaviour
{
    public Transform target;
    private Vector3 posDefaul;
   // public Button btnTest;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        //btnTest.onClick.AddListener(() => Throw());

    }
    private void Update()
    {

        //transform.position = posDefaul;

    }
    public void Throw()
    {
        transform.LookAt(target);
        //anim.SetTrigger("Throw");
    }
    public void Throwing()
    {
        Debug.Log("girl throwing");

    }
    public void LookTarget()
    {
        transform.LookAt(target);
    }
}
