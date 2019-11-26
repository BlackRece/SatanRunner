using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{

    public void PlayGame()
    {

        SceneManager.LoadScene("devil game");

    }

    public void QuitGame()
    {

        Debug.Log("this works");
        Application.Quit();

    }

}
