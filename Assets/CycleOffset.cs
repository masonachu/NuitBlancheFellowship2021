using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleOffset : MonoBehaviour
{
    private Animator anim;

    private void Awake() {

        anim = GetComponent<Animator>();
        anim.SetFloat("CycleOffset", Random.Range(0f, 1f));
        anim.SetBool("IsFlying", true);
    }
}
