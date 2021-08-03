using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerParentOnLoad : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    private void Awake() {

        player = GameObject.FindWithTag("Player");
        player.gameObject.transform.SetParent(this.transform);
    }
}
