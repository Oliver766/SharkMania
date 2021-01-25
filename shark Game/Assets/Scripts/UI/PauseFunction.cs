using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFunction : MonoBehaviour
{
   

    public void Pause()  // pause function for if statement
    {
        if(!GameController.IsPlaying) // if game is playing
        {

            return; // returns value

        }

        if (gameObject.activeInHierarchy ==  false) // pause menu starts as not active in scene
        {
            gameObject.SetActive(true); //  pause menu is then active in scene
            Time.timeScale = 0; // time scale equalls 0
            Cursor.lockState = CursorLockMode.None; // cursor lockmode is disabled and user is able to use the cursor.




        }
        else
        {
            gameObject.SetActive(false); // if pause function is not used then menu remains inactive
            Time.timeScale = 1; // time scale still equals 1
            Cursor.visible = true; // cursor is still visible
            Cursor.lockState = CursorLockMode.None;  // cursor lockmode is disabled and user is able to use the cursor.
        }
             
        
    }

    public void RestartGame() // function for  restarting game
    {



        GameController.Restart(); // calls gamecontroller function
       

    }


    public void MainMenu() // function to go back to main menu
    {

        
        GameController.MainMenu(); //  calls gamecontroller function



    }

   


}



