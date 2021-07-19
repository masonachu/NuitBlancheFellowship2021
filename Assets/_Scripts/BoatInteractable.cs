using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicVehicleSystem;

public class BoatInteractable : InteractiveController 
{
    private bool isActive;
    private GameObject player;
    private FirstPersonAIO playerController;
    private BoxCollider bc;

    public Camera playerCamera;
    public KinematicBasicVehicle vechicleSystem;

    public GameObject boatPlayer;

    [Header("Teleport Zones")]
    public Transform activeLocation;
    public Transform deactiveLocation;


    public override void Update() {
        base.Update();

        if (isActive) {

            ExitBoat();
            image.gameObject.SetActive(false);
        }
        else {
            image.gameObject.SetActive(true);
        }
    }

    public override void InteractWithObject() {

        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<FirstPersonAIO>();
        playerCamera = player.GetComponentInChildren<Camera>();

        if (!isActive && !isInteracted) {
            
            //Set bools to true
            isInteracted = true;
            isActive = true;

            //Put player prefab inside of Boat interactable prefab
            player.transform.SetParent(this.gameObject.transform);
            player.transform.position = activeLocation.position;

            //Disable player prefab and turn on BoatPlayer prefab
            boatPlayer.SetActive(true);
            playerController.enableCameraMovement = false;
            playerController.controllerPauseState = true;

            vechicleSystem.inputActive = true;

            //Complete single interaction loop
            isInteracted = false;
        }

        else if (isActive && !isInteracted) {

            //Set bools to false
            isInteracted = false;
            isActive = false;

            //Take player prefab out of parent 
            player.transform.SetParent(null);

            //Revert back to player prefab controls and disable boatPlayer prefab
            playerCamera.gameObject.SetActive(true);
            playerController.enableCameraMovement = true;
            playerController.controllerPauseState = false;

            vechicleSystem.inputActive = false;
            boatPlayer.SetActive(false);
        }
    }

    public void OnChildTriggerEntered(Collider other, Vector3 childPosition) {

        if (other.CompareTag("Player") && !canvasActive & !inTrigger) {

            canvas.transform.LookAt(Camera.main.transform.position, Vector3.up);

            image.gameObject.SetActive(true);
            inTrigger = true;

            //Sound effect here
            canvasActive = true;
        }
    }

    public void OnChildTriggerExit(Collider other, Vector3 childPosition) {

        if (other.CompareTag("Player") && canvasActive && inTrigger) {

            image.gameObject.SetActive(false);
            inTrigger = false;

            //Sound effect here
            canvasActive = false;
        }
    }

    private void ExitBoat() {

        if(isActive && Input.GetKeyDown(KeyCode.E)) {

            //Set bools to false
            isInteracted = false;
            isActive = false;

            //Take player prefab out of parent and teleport player to Activate zone 
            player.transform.SetParent(null);
            player.gameObject.transform.position = activeLocation.transform.position;

            //Revert back to player prefab controls and disable boatPlayer prefab
            playerCamera.gameObject.SetActive(true);
            playerController.enableCameraMovement = true;
            playerController.controllerPauseState = false;

            vechicleSystem.inputActive = false;
            boatPlayer.SetActive(false);
        }
    }
}
