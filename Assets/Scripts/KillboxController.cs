using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxController : MonoBehaviour
{
    static public bool killboxReached = false; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            FollowCam.POI = null;
        } 
    }
}
