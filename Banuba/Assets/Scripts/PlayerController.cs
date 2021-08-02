using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    //bool bonus = false;
    //bool bonusCrash=false;
    //bool bonusScale=false;
    //bool bonusCrashWork = false;

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)) SetPositionMouse();
        if (Input.touchCount > 0) SetPositionTouch();

    }

    void SetPositionMouse()
    {
      
        Vector2 mouse = Input.mousePosition;
        Vector2 touchpos2 = Camera.main.ScreenToWorldPoint(mouse);
       
     
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] raycasts = Physics2D.RaycastAll(ray, Vector2.zero);



        if (raycasts.Length > 0)
        {
            foreach (RaycastHit2D hit in raycasts)
            {
                if (hit.collider.tag == "TouchPanel")
                {
                    transform.position = new Vector2(touchpos2.x, transform.position.y);

                }
            }
            
        }
       

        
}
    void SetPositionTouch()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchpos1 = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, transform.position.y));
        //transform.position = touchpos1;


        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] raycasts = Physics2D.RaycastAll(ray, Vector2.zero);

        if (raycasts.Length > 0)
        {
            foreach (RaycastHit2D hit in raycasts)
            {
                if (hit.collider.tag == "TouchPanel")
                {
                    transform.position = new Vector2(touchpos1.x, transform.position.y);

                }
            }

        }
    }


        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bonusCrash"))
        {
            Debug.Log("I got bonus");
            collision.gameObject.SetActive(false);

        }
        if (collision.gameObject.CompareTag("bonusScale"))
        {
            gameObject.transform.localScale = new Vector2(transform.localScale.x * 0.9f, transform.localScale.x * 0.9f);
            collision.gameObject.SetActive(false);
        }
        
        //if (bonusCrash) { return; }
        //if (bonusScale) { return; }
        //if (bonusCrashWork) { }
        else
        {
            Debug.Log("Game Over");
            GameObject.Find("SceneManager").GetComponent<ChangeScene>().GameOver();
        }
    }
   
}
