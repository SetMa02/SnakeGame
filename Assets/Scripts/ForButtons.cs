using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForButtons : MonoBehaviour
{
    private bool isPause;
  public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void PauseClick()
    {
        if (isPause == true)
        { 
            Time.timeScale = 1;
            isPause = false;
        }
        else
        { 
            Time.timeScale = 0;
            isPause = true;
        }
    }
    /*
    private IEnumerator Pause()
    {
        if(isPause)
        {
            
        }
    }
    */
}
