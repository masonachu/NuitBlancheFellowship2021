using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BottleInteractable : InteractiveController
{
    [SerializeField] private GameObject cork;

    //References to FMOD events
    [Header("FMOD Events")]
    [EventRef] public string bottleOpen;
    [EventRef] public string poem;
    private StudioEventEmitter emit;

    private bool isPlaying;

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
            cork.SetActive(false);
            RuntimeManager.PlayOneShot(bottleOpen, transform.position);
            isInteracted = true;

            //set and play poem
            emit.Event = poem;
            emit.Play();

            //yield until the emitter stops playing.
            yield return new WaitUntil(() => !emit.IsPlaying());

            //After we have waited x seconds set interacted to false.
            isInteracted = false;
        }
    }
}
