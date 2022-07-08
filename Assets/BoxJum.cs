using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJum : MonoBehaviour
{
    public float animation;
    public float height;
    public float distance;
    public float unknow;
    public Vector3 start;
    public GameObject target;
    private Rigidbody rg;
    public Vector3 force;
    public float forceVlue;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        start = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //animation += Time.deltaTime;
        //animation = animation % 5;
        Debug.Log($"animation : {animation}");
        
        
        //transform.position = MathParabola.Parabola(Vector3.zero, Vector3.right * distance,5f,10f);
    }
    public void Projectile()
    {
        transform.position = MathParabola.Parabola(start,target.transform.position, height, animation / unknow);
        force = transform.position;
        rg.AddForce(force * forceVlue);
    }
}
