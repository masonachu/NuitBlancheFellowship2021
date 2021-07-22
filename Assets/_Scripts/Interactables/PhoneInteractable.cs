using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PhoneInteractable : InteractiveController {

    [SerializeField] private GameObject phoneReceiver;
    [SerializeField] private SimpleButtonActivate portalActivator;

    //References to FMOD events
    [Header("FMOD Events")]
    [EventRef] public string phonePickup;
    [EventRef] public string phonePutdown;
    [EventRef] public string poem;
    private StudioEventEmitter emit;

    public override void Awake() {

        base.Awake();
        emit = gameObject.AddComponent<StudioEventEmitter>();
    }


    public override void InteractWithObject() {

        StartCoroutine(BeginCall());
    }

    IEnumerator BeginCall() {

        if (!isInteracted) {

            //Start Coroutine and disable phone receiver object.
            phoneReceiver.SetActive(false);
            RuntimeManager.PlayOneShot(phonePickup, transform.position);
            isInteracted = true;

            //Activate the portal
            portalActivator.ActivatePortal();

            //set and play poem
            emit.Event = poem;
            emit.Play();

            //yield until the emitter stops playing.
            yield return new WaitUntil(() => !emit.IsPlaying());

            //After we audio is finished, put phone receiver back.
            phoneReceiver.SetActive(true);
            RuntimeManager.PlayOneShot(phonePutdown, transform.position);
            isInteracted = false;
        }
    }
}
