using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButtonActivate : MonoBehaviour
{
    public GameManager GameManager;

    [SerializeField] private GameObject portal1;
    [SerializeField] private GameObject portal2;
    [SerializeField] private bool isActive = false;

    private void Start() {

        portal1.SetActive(false);
        portal2.SetActive(false);

        GameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        //if (GameManager.DebugMode) {
        //    DebugActivatePortal(KeyCode.Q);
        //}
    }

    private void DebugActivatePortal(KeyCode key)
    {
        if(Input.GetKeyDown(key) && !isActive)
        {
            portal1.SetActive(true);
            //portal2.SetActive(true);

            isActive = true;
            Debug.Log("Portal is Active");
        }
        else if(Input.GetKeyDown(key) && isActive)
        {
            portal1.SetActive(false);
            //portal2.SetActive(false);

            isActive = false;
            Debug.Log("Portal is Not Active");
        }
    }
    
    public void ActivatePortal()
    {
        if(!isActive) {

            portal1.SetActive(true);
            //portal2.SetActive(true);

            isActive = true;
            Debug.Log("Portal is Active");
        }
    }
}
