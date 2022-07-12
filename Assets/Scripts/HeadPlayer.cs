using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPlayer : MonoBehaviour
{
    public Character player;
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"impact");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log($"impact head");
            if(collision.relativeVelocity.magnitude>2)
            {
                Debug.Log($"Velocity {collision.relativeVelocity.magnitude}");
            }

        }
    }
}
