using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLine : MonoBehaviour
{
    public float speed = 2;
  
    void FixedUpdate()
    {
        if (!gameStates.activeMenu) { transform.Translate(speed * Vector3.down * Time.deltaTime); }
    }

    
}
   
