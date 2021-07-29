using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicVehicleSystem;

public class BoatInteractable : InteractiveController {

    private bool isActive;
    private bool boatActive;

    [Header("References")]
    public Camera playerCamera;
    public KinematicBasicVehicle vechicleSystem;
    public GameObject boatPlayer;

    private GameObject player;
    private FirstPersonAIO playerController;
    private BoxCollider bc;

    [Header("Teleport Zones")]
    public Transform activeLocation;
    public Transform deactiveLocation;


    public override void Update() {

        base.Update();

        if (isActive) {

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
            //player.transform.SetParent(null);

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
            Debug.Log("In Trigger");
        }
    }

    public void OnChildTriggerExit(Collider other, Vector3 childPosition) {

        if (other.CompareTag("Player") && canvasActive && inTrigger) {

            image.gameObject.SetActive(false);
            inTrigger = false;

            //Sound effect here
            canvasActive = false;
            Debug.Log("Outside");
        }
    }

    private void ExitBoat() {

        if (isActive && boatActive && Input.GetKeyDown(KeyCode.E)) {

            //Take player prefab out of parent and teleport player to Activate zone 
            player.transform.SetParent(null);
            player.gameObject.transform.position = activeLocation.transform.position;

            //Revert back to player prefab controls and disable boatPlayer prefab
            playerCamera.gameObject.SetActive(true);
            playerController.enableCameraMovement = true;
            playerController.controllerPauseState = false;

            vechicleSystem.inputActive = false;
            boatPlayer.SetActive(false);

            //Set bools to false
            isInteracted = false;
            isActive = false;
            boatActive = false;
        }

        else if (isActive && !boatActive && Input.GetKeyDown(KeyCode.E)) {
            boatActive = true;
        }
    }
}
