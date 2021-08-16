using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatforMove : MonoBehaviour
{
    public Transform startpostion;
    //public GameObject floar;

    public List<GameObject> floar;

    //public float timeSpawn = 16.5f;
    void Start()
    {
        //StartCoroutine(vehicledelay);
        //timeSpawn = timeSpawn / ((platform.speed + platform.gainSpeed) / platform.speed); //неправильно мне кажется - нужно создавть переменный для текущей и предыдущей скорости на каждой итерации
       // InvokeRepeating("vehicledelay",0.1f,16.5f);
    }

    public void vehicledelay()

    {
        GameObject floarinstance;
        floarinstance = Instantiate(floar[Random.Range(0, floar.Count)], new Vector3(0,0,125), Quaternion.identity) ;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "GameSetup") vehicledelay();

    }

}
