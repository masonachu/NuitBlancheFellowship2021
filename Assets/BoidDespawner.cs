using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidDespawner : MonoBehaviour
{

    public bool inTrigger;

    private void OnTriggerExit(Collider other) {

        if (other.CompareTag("Player")) {

            CheckForBoids();
            inTrigger = false;
        }
    }


    void CheckForBoids() {

        GameObject[] boids = GameObject.FindGameObjectsWithTag("Boid");
        foreach (GameObject boid in boids)
        GameObject.Destroy(boid);
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player")) {

            OnParentTriggerEnter();
        }
    }

    void OnParentTriggerEnter() {

        inTrigger = true;
    }
}
