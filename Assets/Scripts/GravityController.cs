using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float pullPower;
    public bool isComet;
    
    private bool powerUsed = false;
    private bool launched = false;
    private List<GameObject> wells = new List<GameObject>();
    private List<GameObject> antiWells = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Gravity Well")) {
            wells.Add(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Anti Gravity")) {
            antiWells.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Gravity Well")) {
            wells.Remove(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Anti Gravity")) {
            antiWells.Remove(other.gameObject);
        }
    }

    private void FixedUpdate() {
        Vector3 gravToApply = Vector3.one;
        if (wells.Count > 0 && !powerUsed) {
            foreach (GameObject well in wells) {
                gameObject.transform.LookAt(well.transform);
                gravToApply += gameObject.transform.forward * pullPower;
            }            
        }
        else if (antiWells.Count > 0 && !powerUsed) {
            foreach (GameObject antiWell in antiWells) {
                gameObject.transform.LookAt(antiWell.transform);
                gravToApply += gameObject.transform.forward * -1f * pullPower;
            }
        }
        gameObject.GetComponent<Rigidbody>().AddForce(gravToApply);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (launched && isComet) {
                powerUsed = true;
            } else if (!launched) {
                launched = true;
            }
        }
    }
}
