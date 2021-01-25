using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverFunction : MonoBehaviour
{
    /// <summary>
    /// Text objects for score and distance HUD
    /// </summary>
    public Text Distance;
    public Text Score;


    
    private void Start()
    {
        Distance.text = Mathf.Round(GameController.Distance).ToString() + "m"; // Writes distance on screen as number is converted into a whole number
        Score.text = GameController.Score.ToString();// Writes score on screen as number 

    }


}



