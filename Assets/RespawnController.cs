using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private GameManager gm;
    private TimelineManager tl;
    private FirstPersonAIO playerController;

    public Transform spawnArea;
    private void Awake() {

        tl = GetComponentInParent<TimelineManager>();
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonAIO>();
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player") && playerController.playerCanMove) {

            tl.PlayTimeline();
        }
    }

    public void RespawnPlayer() {

        gm.TeleportPlayer(spawnArea);
    }

    public void ToggleCameraMovement() {

        if (playerController.enableCameraMovement) {

            playerController.enableCameraMovement = false;
        }
        else playerController.enableCameraMovement = true;
    }
}
