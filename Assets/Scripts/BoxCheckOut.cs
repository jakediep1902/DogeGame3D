using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheckOut : MonoBehaviour
{
    GameController gameController;
    private void Start()
    {
        gameController = GameController.Instance;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {               
            other.gameObject.GetComponent<Character>().MoveOut();
        }
    }
}
