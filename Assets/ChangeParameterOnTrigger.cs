using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ChangeParameterOnTrigger : MonoBehaviour
{
    private StudioEventEmitter emit;

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {

            emit = GameObject.FindGameObjectWithTag("Music").GetComponent<StudioEventEmitter>();
            emit.SetParameter("Piano Distance", 1f);
        }
    }
    
    private void OnTriggerExit(Collider other) {

        if (other.CompareTag("Player")) {
            
            emit.SetParameter("Piano Distance", 2f);
        }
    }
}
