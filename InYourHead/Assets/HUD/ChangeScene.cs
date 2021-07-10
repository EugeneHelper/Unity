using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets;

public class ChangeScene : MonoBehaviour
{
    public delegate void Message();

    public void Continue()
    {
        DataHolder.LoadGameForContinue();
        SceneManager.LoadScene("GameLevel");
    }
    public void PlayGame()
    {
        DataHolder.LoadGameForPlay();
        SceneManager.LoadScene("GameLevel");
      
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            MainMenu();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
