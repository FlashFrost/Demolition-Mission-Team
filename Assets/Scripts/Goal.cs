﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    static public bool goalMet = false;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Comet")) {
            Debug.Log("Ello?");
            Goal.goalMet = true;

            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }

    /*
    private void OnColliderEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Goal.goalMet = true;

            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
