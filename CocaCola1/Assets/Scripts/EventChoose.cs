using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts;
public class EventChoose : MonoBehaviour
{
    //public GameObject replacementKnife;
   // public UnityEvent replaceEvent;
    bool flag = true;
    public GameObject knife1, knife2, tehnologyKnife;
    public Animator animSeveralInstr;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (platform.gainSpeed > 9.1f && flag == true)
        {
            Debug.Log("1 state event");
            ReplaceFunc();
            flag = !flag;
        }
    }

    public void ReplaceFunc()
    {
        Debug.Log("2 state Eveeent");
        knife1.SetActive(false);
        tehnologyKnife.SetActive(true);
       // animSeveralInstr.enabled = false;
       // animSeveralInstr.SetInteger("int",1);
    }
}

