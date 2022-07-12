using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject target;
    Rigidbody rg;
   
    public float throwForce;
    public float animation;
    public float height;
    public float distance;
    public float unknow;
    private void OnEnable()
    {
        
        rg = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Target");     
    }
    public void MoveStraight()
    {
        Vector3 force = target.transform.position - transform.position;
        force.Normalize();
        rg.AddForce(force * throwForce);
       
    }
    public void MoveParabola()
    {
        animation += Time.deltaTime;
        animation = animation % 5;
        //Debug.Log($"animation : {animation}");
        transform.position = MathParabola.Parabola(transform.position, target.transform.position, height, animation / unknow);
    }
   
}
