using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float pullPower;

    private bool projectileInside = false;
    private GameObject gravityWell;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Gravity Well")) {
            Debug.Log("ELLO?");
            projectileInside = true;
            gravityWell = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Gravity Well")) {
            Debug.Log("GOBYE?");
            projectileInside = false;
            gravityWell = null;
        }
    }

    private void FixedUpdate() {
        if (projectileInside && gravityWell != null) {
            gameObject.transform.LookAt(gravityWell.transform);
            gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * pullPower);
        }
    }
}
