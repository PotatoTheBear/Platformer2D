using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("StartingScreen");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
