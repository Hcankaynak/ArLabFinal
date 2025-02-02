﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class SecondMain : MonoBehaviour
{
    public GameObject Oxygen;
    public GameObject Azote;
    public GameObject Chlorine;
    public GameObject Hydrogen;
    public GameObject Carbon;
    public GameObject select;

    public float maxRayDistances = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        select = null;
    }

    // Update is called once per frame
    void Update()
    {
        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            //we'll try to hit one of the plane collider gameobjects that were generated by the plugin
            //effectively similar to calling HitTest with ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent
            if (Physics.Raycast(ray, out hit, maxRayDistances))
            {
                if (hit.collider.tag == "Surface")
                {
                    if (select != null)
                    {
                        GameObject go = Instantiate(select, hit.point + new Vector3(0,0.5f,0), transform.rotation);
                        select = null;
                    }
                }
            }

        }
    }

    public void selectOxygen()
    {
        select = Oxygen;
    }

    public void selectHydrogen()
    {
        select = Hydrogen;
    }

    public void selectAzote()
    {
        select = Azote;
    }
    public void selectChlorine()
    {
        select = Chlorine;
    }
    public void selectCarbon()
    {
        select = Carbon;
    }

}