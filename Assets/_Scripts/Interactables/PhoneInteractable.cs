using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInteractable : InteractiveController
{
    [SerializeField] private GameObject phoneReceiver;

    public override void InteractWithObject() {

        StartCoroutine(BeginCall());
    }

    IEnumerator BeginCall() {

        if (!isInteracted) {

            //Start Coroutine and disable phone receiver object.
            phoneReceiver.SetActive(false);
            isInteracted = true;

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(5);

            //After we have waited x seconds put phone receiver back.
            //You can swap this out with the FMOD "IsPlaying" function
            phoneReceiver.SetActive(true);
            isInteracted = false;
        }
    }
}
