using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{   //the speed variable that can be changed for each object.
    //float levelSpeed;


    // Update is called once per frame
    void Update()
    {
        //Moves the level pieces from right to left 
        if (GameController.IsPlaying == true)
        {
            transform.Translate(-GameController.Speed * Time.deltaTime, 0f, 0f);
        }
        if (transform.position.x < -33)
        {
            gameObject.SetActive(false);
        }
    }
}
