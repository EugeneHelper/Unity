using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PortalControl : MonoBehaviour
{
    private ARRaycastManager ARRaycastManagerSsript;
    public GameObject Portal;
    public GameObject Robot;

    private GameObject ArPortal;
    public bool isActivePortal = false;
    
    private Animation PortalAnim;
    private GameObject text;
    
    // Start is called before the first frame update
    void Start()
    {
        ARRaycastManagerSsript = FindObjectOfType<ARRaycastManager>();
        text = GameObject.FindWithTag("Text");
            
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivePortal==false) SetPortal();
    }

     void SetPortal()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        Touch touch = Input.GetTouch(0);

        ARRaycastManagerSsript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        

        if (hits.Count > 0 && Input.touchCount > 0 && !isActivePortal)
        {
            text.SetActive(false);
            ArPortal = Instantiate(Portal, hits[0].pose.position, Portal.transform.rotation);
            isActivePortal = true;
            ArPortal.GetComponent<Animation>().Play("PortalAnimation");

            StartCoroutine(routine: AppearDisapperPortal());
        }

        
    }
    private IEnumerator AppearDisapperPortal()
    {
        yield return new WaitForSeconds(2);
        Instantiate(Robot, ArPortal.transform.position, Robot.transform.rotation);
         
        yield return new WaitForSeconds(2);
        ArPortal.GetComponent<Animation>().Play("ClosePortal");

    }
}
