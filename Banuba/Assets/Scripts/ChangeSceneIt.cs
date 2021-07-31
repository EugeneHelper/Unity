using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneIt : MonoBehaviour
{
    public GameObject MenuPanel;

    public DisableAfterTime LINE_1;
   
    public void PlayGame()
    {
        Debug.Log("PlayGame");
        // DataHolder.LoadGameForPlay();
        // gameStates.StartGame = true;
        gameStates.activeMenu = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        MenuPanel.SetActive(false);
       // LINE_1.enabled = true;

    }

    
    public void MainMenu()
    {
        Debug.Log("MainMenu");
        gameStates.activeMenu = true;
        MenuPanel.SetActive(true);
        LINE_1.enabled=false;

        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        gameStates.activeMenu = true;
        MenuPanel.SetActive(true);
        

    }
}
