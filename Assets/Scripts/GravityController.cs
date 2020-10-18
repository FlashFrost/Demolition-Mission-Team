using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float pullPower;

    private List<GameObject> wells = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Gravity Well")) {
            wells.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Gravity Well")) {
            wells.Remove(other.gameObject);
        }
    }

    private void FixedUpdate() {
        if (wells.Count > 0) {
            Vector3 gravToApply = Vector3.one;        
            foreach (GameObject well in wells) {
                gameObject.transform.LookAt(well.transform);
                gravToApply += gameObject.transform.forward * pullPower;
            }
            gameObject.GetComponent<Rigidbody>().AddForce(gravToApply);
        }
    }
}
