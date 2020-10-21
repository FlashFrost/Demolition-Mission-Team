using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSoundsController : MonoBehaviour
{
    public AudioClip muffBoom;
    public AudioClip winDing;

    private AudioSource audioSource;

    private void Awake() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Gravity Well")) {
            audioSource.clip = muffBoom;
            audioSource.Play();
            gameObject.GetComponent<Rigidbody>().Sleep();
            //Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Goal")) {
            audioSource.clip = winDing;
            audioSource.Play();
            gameObject.GetComponent<Rigidbody>().Sleep();
            //Destroy(gameObject);
        }
    }
}
