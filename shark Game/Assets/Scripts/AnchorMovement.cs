using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AnchorMovement : MonoBehaviour
{
    
    public bool move = false;
    public float anchorSpeed;

    // check player collision
    void OnTriggerEnter(Collider other)
    {
        //checks if collision object is tagges as player
        if (other.CompareTag("Player"))
        {
            //sets move bool to true
            move = true;
            //Debug.Log("move is true");

        }
    }

    // Update is called once per frame
    void Update()
    {
        //checks if move is true
        if (move)
        {
            //if move is true, the anchor will move at the speed decided on the y axis 
            // Debug.LogWarning("anchor is moving");
            transform.Translate(0f, anchorSpeed * Time.deltaTime, 0f);
            Destroy(gameObject, 5);
        }
    }
}
