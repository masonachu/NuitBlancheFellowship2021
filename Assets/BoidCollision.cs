using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag != "Boid") {

            Physics.IgnoreCollision(col.collider, GetComponent<Collider>());
        }
    }
}
