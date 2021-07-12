using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInteractable : InteractiveController 
{
    public bool isActive;
    private BoxCollider bc;

    [HideInInspector] public GameObject player;

    [Header("Teleport Zones")]
    public Transform activeLocation;
    public Transform deactiveLocation;

    public override void InteractWithObject() {

        player = GameObject.FindGameObjectWithTag("Player");

        if (!isActive && !isInteracted) {
            isInteracted = true;
            isActive = true;
            //player.transform.SetParent(this.gameObject.transform);
            player.transform.position = activeLocation.position;
            isInteracted = false;
        }

        else if (isActive && !isInteracted) {
            isInteracted = false;
            isActive = false;
            player.transform.position = deactiveLocation.position;
        }
    }
}
