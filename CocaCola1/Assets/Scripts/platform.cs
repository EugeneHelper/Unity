using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class platform : MonoBehaviour
{
    public float speed=9;
   
    public static float gainSpeed=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (SceneManager.GetActiveScene().buildIndex <= 15)
        //{
        //    speed = 9;
        //}
        //else if (SceneManager.GetActiveScene().buildIndex <= 25)
        //{
        //    speed = 18;
        //}
        //else if (SceneManager.GetActiveScene().buildIndex <= 50)
        //{
        //    speed = 24;
        //}
        //else if (SceneManager.GetActiveScene().buildIndex <= 100)
        //{
        //    speed = 30;
        //}

        gainSpeed = speed + GameManager.score * 0.01f;
        
        transform.Translate(0, 0, -gainSpeed * Time.deltaTime);

        if (transform.position.z < -140)
        {
            //FindObjectOfType<PlatforMove>().vehicledelay();
            Destroy(this.gameObject);
        }
    }


    //gainSpeed = GameManager.score* 0.01f;
        
    //    transform.Translate(0, 0, -(speed+gainSpeed) * Time.deltaTime);

}
