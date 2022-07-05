using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject target;
    Rigidbody rg;
    public float throwForce;
    private void OnEnable()
    {
        rg = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");

        Vector3 force = target.transform.position - transform.position;
        force.Normalize();
        rg.AddForce(force * throwForce) ;
    }
    
}
