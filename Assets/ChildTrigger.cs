using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    public BoatInteractable parent;

    void OnTriggerEnter(Collider other) {

        //Allows for parent object to reference the trigger on this gameObject
        parent.OnChildTriggerEntered(other, transform.position);
    }
    
    void OnTriggerExit(Collider other) {

        //Allows for parent object to reference the trigger on this gameObject
        parent.OnChildTriggerExit(other, transform.position);
    }
}
