using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePrefabOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject shed;
    [SerializeField] private Animator anim;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            shed.SetActive(false);
            anim.SetBool("isTriggered", true);
            Debug.Log("wave incoming!");
        }
    }
}
