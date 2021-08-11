using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private GameManager gm;
    private TimelineManager tl;
    private FirstPersonAIO playerCamera;

    public Transform spawnArea;
    private void Awake() {

        tl = GetComponentInParent<TimelineManager>();
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonAIO>();
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player")) {

            tl.PlayTimeline();
        }
    }

    public void RespawnPlayer() {

        gm.TeleportPlayer(spawnArea);
    }

    public void ToggleCameraMovement() {

        if (playerCamera.enableCameraMovement) {

            playerCamera.enableCameraMovement = false;
        }
        else playerCamera.enableCameraMovement = true;
    }
}
