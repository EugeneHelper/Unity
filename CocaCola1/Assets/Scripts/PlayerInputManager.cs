using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour {


    public bool mouseCliked;
    public float speed;
    public GameObject knfe, facturedknife;

    public Animator animator1,animator2;

    //public Transform knife;

    //public void ReplaceFunc()
    //{
    //    Debug.Log("2 state Eveeent");
    //    knife1.SetActive(false);
    //    knife2.SetActive(true);
    //    //GetComponent<Animator>().SetInteger();
    //}
    void Start()
    {
        
    }

   

	void Update () {

        //if (mouseCliked)
        //{
        //    ReplaceFunc();
        //}

      if (Input.GetMouseButtonDown(0))
        { 
            //GetComponent<Animator>().enabled = true;
           animator1.enabled = true;
           animator2.enabled = true;
           // GetComponent<Animator>().SetBool();
        }

      if (Input.GetMouseButtonUp(0))
		{
			//GetComponent<Animator>().enabled = false;
			animator1.enabled = false;
			animator2.enabled = false;

            knfe.transform.rotation = Quaternion.Euler(0, 0, -45f);
            //Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -45f), speed * Time.deltaTime);
        }
	}
  

   




}
