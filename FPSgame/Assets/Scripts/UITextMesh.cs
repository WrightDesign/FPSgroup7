using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * Author: [Barragan, Maritza]
 * Date: [12/08/2023]
 * [This controls all the main components to the pause and main menu.]
 */


public class UITextMesh : MonoBehaviour
{

    /// <summary>
    /// Variables for the Output text, and the Username.
    /// </summary>
    public TextMeshProUGUI Output;
    public TextMeshProUGUI QuitOutput;
    public TextMeshProUGUI PauseOutput;

    public TMP_InputField Username;

    /// <summary>
    /// Enters the User Name, and throws out the text "Today we  eat:" with the players username.
    /// </summary>
    public void EnterButton()
    {

        
        
        Output.text = " Today we eat : " + Username.text;

        
        MainMenu.Username = Username.text;



    }


    /// <summary>
    /// Throws out words when the player decides to quit the game.
    /// </summary>
    public void QuitButton()
    {

        QuitOutput.text = "Quitiing ain't going to save You!!!";

    }

 
}



    
