using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    private Vector3 posDefaul;
    public Button btnTest;
    private void Start()
    {
        btnTest.onClick.AddListener(() => Throw());
        //anim = GetComponent<Animator>();
    }
    private void Update()
    {

        //transform.position = posDefaul;

    }
    public void Throw()
    {
        //transform.LookAt(target);
        //anim.SetTrigger("Throw");
    }
}
