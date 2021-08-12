using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TriggerShake : MonoBehaviour {

    [SerializeField]
    private CameraShaker cameraShaker;

    [SerializeField]
    private StudioEventEmitter emit;

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {

            cameraShaker = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraShaker>();
            emit = GameObject.FindGameObjectWithTag("UnderwaterArea").GetComponent<StudioEventEmitter>();

            cameraShaker.EndShaking();
            emit.SetParameter("Volume", 0f);
        }
    }
}
