using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject levelcomplete,levelfail,ingame;
    public Text leveltext,scoretext;
    public Image fill1;
    public static int score;
	public GameObject particale;
	public float speed;

    public bool GameOver = false;
	void Start ()
    {
        
	}

	int i = 0;

	void Update ()
    {
        scoretext.text = score.ToString();
        if (GameOver)
        {
            gameover();
        }
   //     if (fill1.fillAmount == 1f && i==0) //убрать этот бар и всё. Вместо него найти откуда вызывается LevelFail. Очевидно там где ломается нож.
   //     {
   //         FindObjectOfType<cameramove>().enabled=true;
   //     }
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
 
    public void LevelFail()
    {
        FindObjectOfType<cameramove>().enabled = true;
        levelfail.SetActive(true);
        //ingame.SetActive(false);
    }
    public void RestartButton()
    {
        score = 0;
        platform.gainSpeed = 0;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		RandomBG.instance.SetRandomBgColor();    
    }
    
    public void gameover()
    {
        GameOver=true;
        FindObjectOfType<PlayerInputManager>().enabled = false;
       //FindObjectOfType<PlayerInputManager>().GetComponent<Animator>().enabled = false;
       // FindObjectOfType<GameController>().GetComponent<BoxCollider>().enabled = false;
        FindObjectOfType<BrakeKnife>().GetComponent<BoxCollider>().enabled = false;
        FindObjectOfType<PlatforMove>().enabled = false;

        FindObjectOfType<platform>().enabled = false;

        
        
	}
}

//// FindObjectOfType<PlayerInputManager>().enabled = false;
//// FindObjectOfType<PlayerInputManager>().GetComponent<Animator>().enabled = false;
////// FindObjectOfType<GameController>().GetComponent<BoxCollider>().enabled = false;
//// FindObjectOfType<BrakeKnife>().GetComponent<BoxCollider>().enabled = false;

//FindObjectOfType<BrakeKnife>().enabled = false;
//GameObject.FindWithTag("Player").SetActive(false);
//GameObject.FindWithTag("GameSetup").SetActive(false);


//FindObjectOfType<PlatforMove>().enabled = false;// существующие оключатся, но создаются новые. поэтому ошибка. надо найти  на чем висит скрипт
//FindObjectOfType<platform>().enabled = false;