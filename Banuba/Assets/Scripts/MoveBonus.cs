using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBonus : MonoBehaviour
{
    public float speed = 2;

    void FixedUpdate()
    {
          transform.Translate(speed * Vector3.down * Time.deltaTime); 
    }


}
