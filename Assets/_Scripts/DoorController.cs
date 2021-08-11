using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start() {

        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other) {

        //anim.SetBool("isOpening", true);
        //anim.SetBool("isClosing", false);

        //put door open sfx
    }

    private void OnTriggerExit(Collider other) {

        anim.SetBool("isClosing", true);
        anim.SetBool("isOpening", false);

        //put door open sfx
    }
}
