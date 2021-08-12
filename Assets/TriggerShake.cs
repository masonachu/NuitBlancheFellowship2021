using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShake : MonoBehaviour {

    private CameraShaker cameraShaker;

    private void OnTriggerEnter(Collider other) {

        cameraShaker = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraShaker>();
        cameraShaker.EndShaking();
    }
}
