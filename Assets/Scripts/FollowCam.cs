﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    public float camZ;
    public float easing = 0.05f;
    private GameObject Launcher;

    public Vector2 minXY = Vector2.zero;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        //if (POI == null)
        //return;

        Vector3 destination;  //= POI.transform.position;

        if (POI == null)
        {
            Launcher = GameObject.FindGameObjectWithTag("Launcher");
            destination = Launcher.transform.position;
            Camera.main.orthographicSize = 25;
        }

        else
        {
            destination = POI.transform.position;

            if (POI.tag == "Projectile")
            {
                if(POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination = Vector3.Lerp(transform.position, destination, easing);

        destination.z = camZ;

        transform.position = destination;

        //Camera.main.orthographicSize = destination.y + 30;
    }

}
