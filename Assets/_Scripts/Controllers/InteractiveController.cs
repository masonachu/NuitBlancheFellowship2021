using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveController : MonoBehaviour
{
    public GameObject interactableObject;

    public Canvas canvas;
    public Image image;

    public bool canvasActive = false;

    public bool inTrigger = false;
    public bool isInteracted = false;

    public virtual void Awake() {
        canvas = GetComponentInChildren<Canvas>();
        image = GetComponentInChildren<Image>();
        image.gameObject.SetActive(false);
    }

    public virtual void Update() {

        if (inTrigger && canvasActive) {
            canvas.transform.LookAt(Camera.main.transform.position, Vector3.up);
            CheckInteractable();
        }
    }

    public virtual void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !canvasActive & !inTrigger) {

            canvas.transform.LookAt(Camera.main.transform.position, Vector3.up);

            image.gameObject.SetActive(true);
            inTrigger = true;

            //Sound effect here
            canvasActive = true;
        }
    }

    public virtual void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") && canvasActive && inTrigger) {

            image.gameObject.SetActive(false);
            inTrigger = false;

            //Sound effect here
            canvasActive = false;
        }
    }


    public virtual void CheckInteractable() {
        
        //If the mouse click is pushed down and the object is currently not interacted with ...
        if(Input.GetMouseButtonDown(0) && !isInteracted) {

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
    }

    public virtual void InteractWithObject() {

        Debug.Log("Interacted with " + interactableObject.transform.name + ". Make sure to override this interactable class!");
    }
}
