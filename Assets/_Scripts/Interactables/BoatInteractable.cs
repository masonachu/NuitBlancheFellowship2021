using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public override void Awake() {

        image.gameObject.SetActive(false);
    }

    public override void Update() {
        
        if (inTrigger && canvasActive)
        {
            canvas.transform.LookAt(Camera.main.transform.position, Vector3.up);
            CheckInteractable();
        }

        if (isActive) {

            image.gameObject.SetActive(false);
            ExitBoat();
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

        //else if (isActive && !isInteracted) {

        //    //Set bools to false
        //    isInteracted = false;
        //    isActive = false;

        //    //Take player prefab out of parent 
        //    //player.transform.SetParent(null);

        //    //Revert back to player prefab controls and disable boatPlayer prefab
        //    playerCamera.gameObject.SetActive(true);
        //    playerController.enableCameraMovement = true;
        //    playerController.controllerPauseState = false;
        //    player.transform.SetPositionAndRotation
        //        (activeLocation.transform.position, 
        //         activeLocation.transform.rotation);
        //    vechicleSystem.inputActive = false;
        //    boatPlayer.SetActive(false);
        //}
    }

    public override void CheckInteractable() {

        //If the mouse click is pushed down and the object is currently not interacted with ...
        if (Input.GetKeyDown(KeyCode.E) && !isInteracted)
        {

            if (!boatActive)
            {

                //Shoot a raycast from the mouse and get the name of the object being interacted with
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {

                    //if the interactable object is the same as the one set in the script...
                    if (hit.transform.name == interactableObject.transform.name)
                    {

                        //Set IsInteracted to true and run InteractWithObject function.
                        //This only allows for ONE interaction usage, unless you use get set function on isInteracted in child scripts

                        InteractWithObject();
                    }
                }
            }

            if(boatActive)
            {
                Debug.Log("CheckInteractable called");
            }
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

        if (Input.GetKeyDown(KeyCode.R)) {

            Debug.Log("Works");

            //Take player prefab out of parent and teleport player to Activate zone 
            player.transform.SetParent(null);
            player.gameObject.transform.position = activeLocation.transform.position;

            //Revert back to player prefab controls and disable boatPlayer prefab
            playerCamera.gameObject.SetActive(true);
            playerController.enableCameraMovement = true;
            playerController.controllerPauseState = false;

            player.transform.SetPositionAndRotation(activeLocation.transform.position, activeLocation.transform.rotation);

            vechicleSystem.inputActive = false;
            boatPlayer.SetActive(false);

            //Set bools to false
            isInteracted = false;
            isActive = false;
            boatActive = false;
        }
    }
}
