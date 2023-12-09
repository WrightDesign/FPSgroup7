using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/*
 * Author: [Barragan, Maritza]
 * Date: [12/08/2023]
 * [This controls all the main components to the pause and main menu.]
 */


/// <summary>
/// The Main Menu.
/// </summary>
public class MainMenu : MonoBehaviour
{


    /// <summary>
    /// Created Static variables for the Username. I know that typically this would have been codded another way, however I had coded it like this due to time.
    /// </summary>
    public static string Username;

    public static int Score;


    /// <summary>
    /// Sends player to the main Scene to start the game.
    /// </summary>
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void PlayGame2()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    /// <summary>
    /// Quits the Game.
    /// </summary>
    public void Quit()
    {

        Debug.Log("Quit!");

        Application.Quit();


    }

  

}


/// <summary>
/// The pause Menu.
/// </summary>
public class PauseUI : MonoBehaviour

{
   
    public GameObject pauseUI;

    public bool isPaused;

   


    private void Start()
    {
      
        pauseUI.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (isPaused) 
            {

                ResumeGame();

            }

            else 
            {

                pauseGame();            
 
            }


        }
    }
    public void pauseGame()
    {

        pauseUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ResumeGame()
    {

        pauseUI.SetActive(false);
        Time.timeScale = 1f;

    }


}

