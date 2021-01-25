using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatTracker : MonoBehaviour
{
    public Text distanceText;
    public Text scoreText;

    //updates Distance and Score to the UI
    void Update()
    {   if (GameController.IsPlaying == true)
        {
            //adds this speed that the shark is traveling to the variable each update
            GameController.Distance += GameController.Speed * Time.deltaTime;
          
            // Debug.Log(GameController.Distance + "distance");
            distanceText.text = Math.Round(GameController.Distance).ToString();

            scoreText.text = GameController.Score.ToString();
        }
    }
}
