using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveController : MonoBehaviour
{
    [SerializeField] private GameObject interactableObject;

    private Canvas canvas;
    private Image image;

    private bool inTrigger = false;
    private bool isInteracted = false;
    private bool isActive = false;
    
    private void Awake() {
        canvas = GetComponentInChildren<Canvas>();
        image = GetComponentInChildren<Image>();
        image.gameObject.SetActive(false);
    }

    private void Update() {

        if (inTrigger && isActive) {
            canvas.transform.LookAt(Camera.main.transform.position, -Vector3.up);
            CheckInteractable();
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !isActive & !inTrigger) {

            canvas.transform.LookAt(Camera.main.transform.position, -Vector3.up);

            image.gameObject.SetActive(true);
            inTrigger = true;

            //Sound effect here
            isActive = true;
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") && isActive && inTrigger) {

            image.gameObject.SetActive(false);
            inTrigger = false;

            //Sound effect here
            isActive = false;
        }
    }


    public virtual void CheckInteractable() {

        if(Input.GetMouseButtonDown(0) && !isInteracted) {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == interactableObject.transform.name) {
                    InteractWithObject();
                }
            }
        }
    }

    public virtual void InteractWithObject() {

        Debug.Log("Interacted with " + interactableObject.transform.name + ". Make sure to override this interactable class!");
    }
}
