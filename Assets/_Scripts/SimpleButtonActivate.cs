using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButtonActivate : MonoBehaviour
{
    public string button;

    [SerializeField] private GameObject portal;
    [SerializeField] private bool isActive = false;

    private void Start()
    {
        portal.SetActive(false);
    }

    private void Update()
    {
        ActivatePortal(button);
    }

    private void ActivatePortal(string key)
    {
        if(Input.GetKeyDown(key) && !isActive)
        {
            portal.SetActive(true);
            isActive = true;
            Debug.Log("Portal is Active");
        }
        else if(Input.GetKeyDown(key) && isActive)
        {
            portal.SetActive(false);
            isActive = false;
            Debug.Log("Portal is Not Active");
        }
    }
}
