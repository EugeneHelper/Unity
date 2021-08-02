using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour
{
    public GameObject MenuPanel;

    public DisableAfterTime LINE_1;

    public ObjectPooler objectPooler;

    public PlayerController playerController;
    public Text textRecord;

    private void Start()
    {
       textRecord.text= PlayerPrefs.GetInt("Record").ToString();
    }
    public void Continue()
    {
        Debug.Log("Continue Game");
        if (!gameStates.gameOver)
        {
            MenuPanel.SetActive(false);
            gameStates.activeMenu = false;
            playerController.enabled = true;
        }
    }

    public void NewGame()
    {

        //LINE_1.DisableLine();
        //LINE_1.enabled = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        foreach(GameObject i in objectPooler.pooledObjects) { i.SetActive(false); }

        Debug.Log("NewGame");
        gameStates.gameOver = false;

        gameStates.activeMenu = false;
        gameStates.Score = 0;

        //////////////////////////////
        ///надо сделать по другому просто мгновенный Disabler здесь вызвать
       // 
       //надо сделать чтобы LINE_1 стал префабом, и всё что происходит с ним происходило и с остальными линиями
       // LINE_1.DisableLine();
        MenuPanel.SetActive(false);
        // LINE_1.enabled = true;
        playerController.enabled = true;
    }

    
    public void MainMenu()
    {
        playerController.enabled = false;
        gameStates.activeMenu = true;


        
        Debug.Log("MainMenu");
        
        MenuPanel.SetActive(true);
        MenuPanel.transform.Find("GameOverText").gameObject.SetActive(false);
        //LINE_1.enabled=false;
        //получить доступ к каждой линии по индексу и отключить у неё Disable 111111111111111111111111111111111111111111


    }

     void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        playerController.enabled = false;
        gameStates.activeMenu = true;
        MenuPanel.SetActive(true);
        LINE_1.enabled = false;
        gameStates.gameOver = true;
        MenuPanel.transform.Find("GameOverText").gameObject.SetActive(true);
        if (gameStates.Score > gameStates.bestScore)
        {
            PlayerPrefs.SetInt("Record", gameStates.Score);
            textRecord.text = gameStates.Score.ToString();

        }
    }

 

}
