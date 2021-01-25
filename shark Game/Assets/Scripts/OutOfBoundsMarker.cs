using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsMarker : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) // if trigger collides with object with player tag
        {
            GameController.GameOver(); //  game over function is started

        }
    }

}


