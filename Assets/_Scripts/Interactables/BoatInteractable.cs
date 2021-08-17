using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KinematicVehicleSystem;

public class BoatInteractable : InteractiveController {

    private bool isActive;
    private int lastPressed;
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

        if (inTrigger || isActive) {

            image.gameObject.SetActive(true);
            CheckInteractable();
        }
    }

    public override void InteractWithObject() {

        //Find references
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<FirstPersonAIO>();
        playerCamera = player.GetComponentInChildren<Camera>();

        //If player isn't already in the boat
        if (!isActive && !isInteracted) {

            //Sets this GO as parent of player GO and teleport the GO to middle of boat
            //player.transform.SetParent(this.gameObject.transform);
            player.transform.SetPositionAndRotation(activeLocation.transform.position, activeLocation.transform.rotation);

            //Disable player prefab and turn on BoatPlayer prefab
            boatPlayer.SetActive(true);
            vechicleSystem.inputActive = true;

            playerCamera.gameObject.SetActive(false);
            playerController.enableCameraMovement = false;
            playerController.playerCanMove = false;
         
            //Set bools to true
            isInteracted = true;
            isActive = true;
        }
    }

    public override void CheckInteractable() {

        //If the mouse click is pushed down and the object is currently not interacted with ...
        if (Input.GetKeyDown(KeyCode.E) && !isInteracted) {                
            
            //Shoot a raycast from the mouse and get the name of the object being interacted with
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {

                //if the interactable object is the same as the one set in the script...
                if (hit.transform.name == interactableObject.transform.name) {

                    //Set IsInteracted to true and run InteractWithObject function.
                    //This only allows for ONE interaction usage, unless you use get set function on isInteracted in child scripts

                    InteractWithObject();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && isActive) {

            lastPressed++;
            if(lastPressed > 1) {

                CheckForBoatExit();
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

    public void CheckForBoatExit() {

        //Take player prefab out of parent and teleport player to Activate zone 
        //player.transform.SetParent(null);
        player.transform.SetPositionAndRotation(activeLocation.transform.position, activeLocation.transform.rotation);

        //Revert back to player prefab controls and disable boatPlayer prefab
        playerCamera.gameObject.SetActive(true);
        playerController.enableCameraMovement = true;
        playerController.playerCanMove = true;

        boatPlayer.SetActive(false);
        vechicleSystem.inputActive = false;

        //Set all bools to false to complete loop
        isInteracted = false;
        isActive = false;
        lastPressed = 0;
    }
}
